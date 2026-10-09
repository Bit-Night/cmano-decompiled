using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class RadarModel
{
	public enum TSurfaceType
	{
		st_Urban,
		st_Mountains,
		st_Cropland,
		st_Shrubland,
		st_Forest,
		st_Desert,
		st_Tundra,
		st_Grassland,
		st_Wetland
	}

	public enum TAntennaType
	{
		at_ITU_R_M1652,
		at_ITU_R_F1245,
		at_Sin_x_x,
		at_Coseq_Sq,
		at_Gaussian,
		at_Height_Finder_Generic,
		at_Height_Finder_Specific,
		at_Dipole,
		at_Phased_Array
	}

	public enum TPolarizationType
	{
		pt_Horizontal,
		pt_Vertical,
		pt_Circular
	}

	public enum TRadarCalcsType
	{
		rct_Simple_Pulsed,
		rct_Integrated_Incoherent,
		rct_Integrated_Coherent,
		rct_CW_Coherent,
		rct_Synthetic_Aperture
	}

	public enum TMultistaticRadarType
	{
		mrt_Incoherent,
		mrt_Coherent,
		mrt_Short_Term_Coherent
	}

	public enum TJammingType
	{
		None = 0,
		jt_Rebroadcast_Pulses_Azimouth_Shift = 1,
		jt_Rebroadcast_Pulses_Elevation_Shift = 2,
		jt_Rebroadcast_Pulses_Decrease = 4,
		jt_Inverse_Jamming = 8,
		jt_Double_Frequency = 0x10,
		jt_Cross_Polarization = 0x20,
		jt_Mirror_Channel = 0x40,
		jt_Multistatic_Coherent = 0x80,
		jt_Multistatic_Incoherent = 0x100,
		jt_Twinkling = 0x200,
		jt_Chaff_Illumination_Broadcast_Delay = 0x400,
		jt_Chaff_Illumination_Broadcast_Delay_Frequency_Shift = 0x800,
		jt_Reflection_Spot = 0x1000,
		jt_Multiple_Synchronous_Pulse = 0x2000,
		jt_Chaotic_Pulse = 0x4000,
		jt_Continuous = 0x8000,
		jt_VGPO = 0x10000,
		jt_RGPO = 0x20000
	}

	[Flags]
	public enum TECCMType
	{
		None = 0,
		et_Double_Pulse = 1,
		et_Rebroadcast_Delay_Detection = 2,
		et_Two_Narrow_Guard_Strobes = 4,
		et_Single_Guard_Strobe = 8,
		et_Pulse_Front_End_Tracking = 0x10,
		et_Pulse_Front_End_Extension = 0x20,
		et_Asymmetric_Strobe_Front_End_Tracking = 0x40,
		et_Pulse_Shortening = 0x80,
		et_Channel_Blanking = 0x100,
		et_Velocity_Guard_Strobes = 0x200,
		et_Velocity_Maintenance_Logic = 0x400,
		et_FFT_Spectrum_Analysis = 0x800,
		et_Double_Frequency_Concurrent = 0x1000,
		et_Double_Frequency_Consecutive = 0x2000,
		et_Triple_Channel_Frequency_Discriminator = 0x4000,
		et_Correlated_Velocity_Range_Processing = 0x8000,
		et_Steerable_Nulls = 0x10000
	}

	public struct TNATORadarBand
	{
		public double LoFreq;

		public double HiFreq;

		public double DefaultFreq;
	}

	public struct TMetricParams
	{
		public double h1;

		public double h2;

		public double range;

		public double Frequency;
	}

	public struct TOpticalParams
	{
		public double opmaxd;

		public double opmaxl;

		public double exloss;

		public double r1min;
	}

	public struct TAntennaParams
	{
		public TAntennaType AntennaType;

		public double antbwr;

		public double antelr;

		public double antfac;

		public double elmaxr;

		public double patrfac;
	}

	public struct TEvapDuctParams
	{
		public double C1;

		public double C2;

		public double C3;

		public double C4;

		public double C5;

		public double C6;

		public double C7;

		public double rfac;

		public double zmax;

		public double zfac;

		public double hmin;

		public double xterm;

		public double zterm;

		public double del;

		public double capk;

		public double difac;

		public double atten;
	}

	public struct TReflection
	{
		public double ReflectionCoeff;

		public double PhaseLag;
	}

	public interface IDoubleMatrix
	{
		double Item { get; set; }
	}

	public sealed class TSteerableNullSet
	{
		protected double[] m_Angles;

		protected double m_Width;

		protected double m_Level;

		public double[] Angles
		{
			get
			{
				return m_Angles;
			}
			set
			{
				m_Angles = value;
			}
		}

		public double Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				m_Width = value;
			}
		}

		public double Level
		{
			get
			{
				return m_Level;
			}
			set
			{
				m_Level = value;
			}
		}

		public TSteerableNullSet()
		{
			m_Angles = new double[0];
			m_Width = 1.0;
			m_Level = -50.0;
		}

		public TSteerableNullSet(int NumAngles)
		{
			m_Angles = new double[0];
			m_Angles = new double[NumAngles - 1 + 1];
			m_Width = 1.0;
			m_Level = -50.0;
		}

		public TSteerableNullSet(int NumAngles, double NullWidth)
		{
			m_Angles = new double[0];
			m_Angles = new double[NumAngles - 1 + 1];
			m_Width = NullWidth;
			m_Level = -50.0;
		}

		public TSteerableNullSet(int NumAngles, double NullWidth, double NullLevel)
		{
			m_Angles = new double[0];
			m_Angles = new double[NumAngles - 1 + 1];
			m_Width = NullWidth;
			m_Level = NullLevel;
		}

		static TSteerableNullSet()
		{
			Class72.smethod_20();
		}
	}

	public interface IEmitter
	{
		double Frequency { get; set; }

		double PowerOutputW { get; set; }

		double Altitude { get; set; }

		double VertBeamWidth { get; set; }

		double HorzBeamWidth { get; set; }

		double AntennaGain { get; set; }

		TSteerableNullSet SteerableNulls { get; set; }

		double ElevationAngle { get; set; }
	}

	public sealed class TRadar : IEmitter
	{
		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		protected double m_RangeResolution;

		protected double m_PRF;

		protected double m_PulseWidth;

		protected double m_MaximumUnambiguousRangeNM;

		protected double m_MinimumRangeNM;

		public float Altitude;

		private TSurfaceAndPeriscopeSearchCapability tsurfaceAndPeriscopeSearchCapability_0;

		public double Frequency;

		public double PowerOutputW;

		public double Velocity;

		protected double m_RecoveryTime;

		public double AntennaTemp;

		public double ReceiverTemp;

		protected double m_ProcessingGain;

		public double AntennaEfficiency;

		public double AzimuthLength;

		public double ElevationLength;

		public int RelativeSidelobeLevel;

		public int BacklobeLevel;

		public BitArray bitArray_0;

		public TAntennaType AntennaType;

		private double QnbypCpPeLC;

		public double ElevationAngle;

		public TRadarCalcsType RadarCalculations;

		public TPolarizationType Polarization;

		public double FalseAlarmRate;

		protected TSteerableNullSet m_SteerableNulls;

		protected double _DetectionSNR_dB;

		protected double _TrackLossSNR_dB;

		public double RangeResolution => m_RangeResolution;

		public double PRF
		{
			get
			{
				return m_PRF;
			}
			set
			{
				m_PRF = value;
				if (value <= 0.0)
				{
					m_MaximumUnambiguousRangeNM = Math.Sqrt(-1.0);
					return;
				}
				m_MaximumUnambiguousRangeNM = 299792458.0 / (2.0 * value) / 1852.0;
				if (ScanRate > 0.0)
				{
					double_3 = HorzBeamWidth * value / (6.0 * ScanRate);
				}
				else
				{
					double_3 = Math.Sqrt(-1.0);
				}
			}
		}

		public double PulseWidth
		{
			get
			{
				return m_PulseWidth;
			}
			set
			{
				m_PulseWidth = value;
				m_RangeResolution = 299792458.0 * value * 1E-06 / 2.0;
				if (m_PulseWidth != 1000.0)
				{
					m_MinimumRangeNM = GetMinimumRangeNM();
				}
				else
				{
					m_MinimumRangeNM = 0.0;
				}
			}
		}

		public double MaximumUnambiguousRangeNM => m_MaximumUnambiguousRangeNM;

		public double MinimumRangeNM => m_MinimumRangeNM;

		double IEmitter.AltitudeM
		{
			get
			{
				return Altitude;
			}
			set
			{
				Altitude = (int)Math.Round(value);
			}
		}

		public TSurfaceAndPeriscopeSearchCapability SurfaceAndPeriscopeSearchCapability
		{
			get
			{
				return tsurfaceAndPeriscopeSearchCapability_0;
			}
			set
			{
				tsurfaceAndPeriscopeSearchCapability_0 = value;
			}
		}

		double IEmitter.FrequencyHz
		{
			get
			{
				return Frequency;
			}
			set
			{
				Frequency = value;
			}
		}

		double IEmitter.PowerOutput
		{
			get
			{
				return PowerOutputW;
			}
			set
			{
				PowerOutputW = value;
			}
		}

		public double RecoveryTime
		{
			get
			{
				return m_RecoveryTime;
			}
			set
			{
				m_RecoveryTime = value;
				m_MinimumRangeNM = GetMinimumRangeNM();
			}
		}

		public double ProcessingGain
		{
			get
			{
				return m_ProcessingGain;
			}
			set
			{
				m_ProcessingGain = value;
			}
		}

		public double AntennaGain
		{
			get
			{
				if (double_2 != double_2)
				{
					if (double_0 == double_0 && double_1 == double_1)
					{
						double_2 = 10.0 * Math.Log10(12.56637061435916 / (2.0 * Math.Sin(HorzBeamWidth * 0.0174532925199433 / 2.0) * VertBeamWidth * 0.0174532925199433));
						return double_2;
					}
					return double_2;
				}
				return double_2;
			}
			set
			{
				double_2 = value;
				if (double.IsNaN(double_0) && !double.IsNaN(double_1))
				{
					double_0 = 12.56637061435916 / (Math.Pow(10.0, value / 10.0) * 2.0 * Math.Sin(double_1 * 0.0174532925199433 / 2.0) * 0.0174532925199433);
				}
				if (double.IsNaN(double_1) && !double.IsNaN(double_0))
				{
					double_1 = 2.0 * Math.Asin(12.56637061435916 / (Math.Pow(10.0, value / 10.0) * 2.0 * double_0 * 0.0174532925199433)) / 0.0174532925199433;
				}
			}
		}

		public double ScanRate
		{
			get
			{
				return QnbypCpPeLC;
			}
			set
			{
				QnbypCpPeLC = value;
				if (value > 0.0 && PRF > 0.0 && ScanRate > 0.0)
				{
					double_3 = HorzBeamWidth * PRF / (6.0 * value);
				}
				else
				{
					double_3 = Math.Sqrt(-1.0);
				}
			}
		}

		public double HorzBeamWidth
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
				if (ScanRate > 0.0 && PRF > 0.0)
				{
					double_3 = value * PRF / (6.0 * ScanRate);
				}
				else
				{
					double_3 = Math.Sqrt(-1.0);
				}
			}
		}

		public double VertBeamWidth
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

		double IEmitter.ElevationAngleDEG
		{
			get
			{
				return ElevationAngle;
			}
			set
			{
				ElevationAngle = value;
			}
		}

		public TSteerableNullSet SteerableNulls
		{
			get
			{
				return m_SteerableNulls;
			}
			set
			{
				m_SteerableNulls = value;
			}
		}

		public double HitsPerScan
		{
			get
			{
				if (ScanRate == 0.0)
				{
					throw new Exception("Zero scan rate! Can't measure hits per scan");
				}
				return double_3;
			}
		}

		public double SystemLoss
		{
			get
			{
				return 0.0 - ProcessingGain;
			}
			set
			{
				ProcessingGain = 0.0 - value;
			}
		}

		public double SystemNoiseLevel
		{
			get
			{
				return Math.Log10((AntennaTemp + ReceiverTemp) / 290.0) * 10.0;
			}
			set
			{
				AntennaTemp = 40.0;
				ReceiverTemp = Math.Pow(10.0, value / 10.0) * 290.0 - AntennaTemp;
			}
		}

		public TRadar()
		{
			m_MinimumRangeNM = 0.0;
			_DetectionSNR_dB = 0.0;
			_TrackLossSNR_dB = 0.0;
			ReceiverTemp = 275.0;
			AntennaTemp = 15.0;
			RecoveryTime = 0.0;
			Altitude = 10f;
			PRF = 100.0;
			ScanRate = 6.0;
			AntennaType = TAntennaType.at_Sin_x_x;
			Polarization = TPolarizationType.pt_Horizontal;
			RadarCalculations = TRadarCalcsType.rct_Simple_Pulsed;
			ElevationAngle = 0.0;
			FalseAlarmRate = 1E-06;
			double_2 = Math.Sqrt(-1.0);
			double_0 = 0.0;
			double_1 = Math.Sqrt(-1.0);
			SteerableNulls = new TSteerableNullSet();
			SurfaceAndPeriscopeSearchCapability = TSurfaceAndPeriscopeSearchCapability.None;
		}

		internal double GetMinimumRangeNM()
		{
			if (m_PulseWidth == 0.0)
			{
				return 0.0;
			}
			return 299792458.0 * (m_PulseWidth + m_RecoveryTime) * 1E-06 * 0.5 / 1852.0;
		}

		internal double DutyCycle()
		{
			if (PRF == 0.0)
			{
				throw new Exception("Zero PRF! Can't measure duty cycle");
			}
			return PulseWidth * 1E-06 * PRF;
		}

		public void AdjustAntennaGain(float multiplier)
		{
			if (!double.IsNaN(double_2))
			{
				double_2 *= multiplier;
			}
		}

		internal double DetectabilityRatio(double ProbDetection, bool IsTargetFluctuating = true)
		{
			double result;
			try
			{
				double falseAlarmRate = FalseAlarmRate;
				double num = 2.36 * Math.Sqrt(0.0 - Math.Log10(falseAlarmRate)) - 1.02;
				double num2 = 0.9 * (2.0 * ProbDetection - 1.0);
				double num3 = 1.23 * num2 / Math.Sqrt(1.0 - num2 * num2);
				double num4 = (num + num3) * (num + num3);
				double num5 = ((!IsTargetFluctuating) ? 1.0 : (1.0 / ((0.0 - Math.Log(ProbDetection)) * (1.0 + num3 / num))));
				result = ((RadarCalculations != TRadarCalcsType.rct_Integrated_Coherent) ? (num5 * num4 * (1.0 + Math.Sqrt(1.0 + 16.0 * HitsPerScan / num4)) / (4.0 * HitsPerScan)) : (num5 * num4 * (1.0 + Math.Sqrt(1.0 + 16.0 / num4)) / (4.0 * HitsPerScan)));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200099", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = 0.0;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		internal double GetDwellTime()
		{
			switch (RadarCalculations)
			{
			case TRadarCalcsType.rct_Simple_Pulsed:
				return PulseWidth * 1E-06;
			case TRadarCalcsType.rct_Integrated_Incoherent:
			case TRadarCalcsType.rct_Integrated_Coherent:
				return HitsPerScan * PulseWidth * 1E-06;
			case TRadarCalcsType.rct_CW_Coherent:
				return HorzBeamWidth / (ScanRate / 6.0);
			case TRadarCalcsType.rct_Synthetic_Aperture:
				return Math.Sqrt(-1.0);
			default:
			{
				double result = default(double);
				return result;
			}
			}
		}

		public void SetGainFromBeamwidth(double HorzBeamwidth, double VertBeamWidth)
		{
			double_1 = HorzBeamwidth;
			double_0 = VertBeamWidth;
			double d = 12.56637061435916 / (2.0 * Math.Sin(double_1 * 0.0174532925199433 / 2.0) * double_0 * 0.0174532925199433);
			double_2 = 10.0 * Math.Log10(d);
		}

		public void SetHorzBeamwidth(double VertBeamwidth, double AntennaGain)
		{
			double_2 = AntennaGain;
			double_0 = VertBeamwidth;
			double_1 = 2.0 * Math.Asin(12.56637061435916 / (Math.Pow(10.0, double_2 / 10.0) * 2.0 * double_0 * 0.0174532925199433)) / 0.0174532925199433;
		}

		public void SetVertBeamwidth(double HorzBeamwidth, double AntennaGain)
		{
			double_2 = AntennaGain;
			double_1 = HorzBeamwidth;
			double_0 = 12.56637061435916 / (Math.Pow(10.0, double_2 / 10.0) * 2.0 * Math.Sin(double_1 * 0.0174532925199433 / 2.0) * 0.0174532925199433);
		}

		static TRadar()
		{
			Class72.smethod_20();
		}
	}

	public sealed class TJammer : IEmitter
	{
		private float float_0;

		private double double_0;

		protected double _BW;

		private double double_1;

		public double Bandwidth;

		protected double _FrequencyHz;

		public double Altitude
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = (int)Math.Round(value);
			}
		}

		double IEmitter.Gain
		{
			get
			{
				return double_0;
			}
			set
			{
				double_0 = value;
				_BW = 9.869604401089338 / Math.Pow(10.0, ((IEmitter)this).AntennaGain / 10.0) * 57.2957795130823;
			}
		}

		double IEmitter.OutputW
		{
			get
			{
				return double_1;
			}
			set
			{
				double_1 = value;
			}
		}

		public double ElevationAngle
		{
			get
			{
				return 0.0;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to set elevation angle!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200222", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}

		public double Frequency
		{
			get
			{
				return _FrequencyHz;
			}
			set
			{
				_FrequencyHz = value;
			}
		}

		public double HorzBeamWidth
		{
			get
			{
				return _BW;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to enter beamwidth for jammers directly!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200223", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}

		public TSteerableNullSet SteerableNulls
		{
			get
			{
				return null;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to add steerable null support to jammers!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200224", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}

		public double VertBeamWidth
		{
			get
			{
				return _BW;
			}
			set
			{
				try
				{
					throw new Exception("You're not supposed to enter beamwidth for jammers directly!");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200225", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
		}

		static TJammer()
		{
			Class72.smethod_20();
		}
	}

	public struct TReceiver
	{
		public float Altitude;

		public double Sensitivity;

		public double SystemLoss;

		public BitArray bitArray_0;

		public double SearchSpeed;

		public double ChannelBandwidth;

		public int NumChannels;
	}

	public sealed class TTarget
	{
		public float Altitude;

		public double RCS;

		public double RadialVelocity;

		public TTargetType ObjectType;

		public double Height;

		public double DeckHeight;

		public double RCS_m2
		{
			get
			{
				return Math.Pow(10.0, RCS / 10.0);
			}
			set
			{
				RCS = 10.0 * Math.Log10(value);
			}
		}

		public TTarget()
		{
			ObjectType = TTargetType.tgt_Unknown;
			Height = 0.0;
			DeckHeight = 0.0;
		}

		static TTarget()
		{
			Class72.smethod_20();
		}
	}

	public enum TTargetType
	{
		tgt_Unknown,
		tgt_FixedWingAircraft,
		tgt_RotaryWingAircraft,
		tgt_SurfaceShip,
		tgt_Satellite,
		tgt_ReentryVehicle,
		tgt_GroundVehicle,
		tgt_GroundFacility
	}

	public enum TSurfaceAndPeriscopeSearchCapability
	{
		None,
		Basic,
		FineRangeResolution,
		AdvancedProcessing
	}

	public enum TPhaseShifterType
	{
		pst_TrueTimeDelay,
		pst_ConstPhase,
		pst_ConstLength
	}

	public sealed class TPhasedArray
	{
		public TPhaseShifterType PhaseShifter;

		public int NumBits;

		public int LSB;

		public double CenterFrequency;

		public double OperatingFrequency;

		public double ElementSpacing;

		private int int_0;

		public int NumElements
		{
			get
			{
				return int_0;
			}
			set
			{
				if ((double)value / 2.0 == Conversion.Fix((double)value / 2.0))
				{
					throw new Exception("Number of phased array elements shall be odd");
				}
				int_0 = value;
			}
		}

		public TPhasedArray()
		{
			PhaseShifter = TPhaseShifterType.pst_TrueTimeDelay;
			NumElements = 11;
		}

		private double method_0(double double_0, double double_1)
		{
			double num = 299792458.0 / CenterFrequency * 100.0;
			double num2 = 299792458.0 / OperatingFrequency * 100.0;
			double a = double_0 * 0.0174532925199433;
			double num3 = 0.0;
			int num4 = -(int)Math.Round((double)(NumElements - 1) / 2.0);
			int num5 = (int)Math.Round((double)(NumElements - 1) / 2.0);
			double num7 = default(double);
			for (int i = num4; i <= num5; i++)
			{
				double num6 = (double)i * 2.0 * 3.14159265358979 * ElementSpacing / num * Math.Sin(a) * 57.2957795130823;
				double n = Math.Abs(num6 - 360.0 * Conversion.Fix(num6 / 360.0));
				switch (PhaseShifter)
				{
				case TPhaseShifterType.pst_TrueTimeDelay:
					num7 = num6 * OperatingFrequency / CenterFrequency;
					break;
				case TPhaseShifterType.pst_ConstPhase:
				{
					double num8 = MRound(n, LSB);
					if (num8 >= 359.9)
					{
						num8 = 0.0;
					}
					num7 = num8 * OperatingFrequency / CenterFrequency;
					break;
				}
				case TPhaseShifterType.pst_ConstLength:
					num7 = MRound(n, LSB);
					if (num7 >= 359.9)
					{
						num7 = 0.0;
					}
					break;
				}
				double num9 = num7 * 0.0174532925199433;
				num3 += Math.Cos(num9 - (double)i * 2.0 * 3.14159265358979 * ElementSpacing / num2 * Math.Sin(double_1 * 0.0174532925199433));
			}
			return num3 / (double)NumElements;
		}

		internal double PatternFactor(double Theta0, double Theta)
		{
			double num = method_0(Theta0, Theta);
			double num2 = method_0(Theta0, Theta0);
			return 20.0 * Math.Log10(num / num2);
		}

		static TPhasedArray()
		{
			Class72.smethod_20();
		}
	}

	public sealed class TChaffCloud
	{
		public double BundlesPerMinute;

		public double DipolesPerBundle;

		public int AircraftSpeed;

		public float ReleaseAltitude;

		public TChaffCloud(int AircraftSpeed, float ReleaseAltitude, double BundlesPerMinute, double DipolesPerBundle)
		{
			this.BundlesPerMinute = BundlesPerMinute;
			this.ReleaseAltitude = ReleaseAltitude;
			this.AircraftSpeed = AircraftSpeed;
			this.DipolesPerBundle = DipolesPerBundle;
		}

		internal double Volume(int Time)
		{
			double num = Time;
			double num2 = 60.0;
			double num3 = num + num2;
			double num4;
			if (num3 * 1.3 > (double)ReleaseAltitude)
			{
				if (num3 * 0.4 > (double)ReleaseAltitude)
				{
					return 0.0;
				}
				num4 = (double)ReleaseAltitude - num3 * 0.4;
			}
			else
			{
				num4 = num3 * 0.9;
			}
			double num5 = num2 * (double)AircraftSpeed * 1852.0 / 3600.0;
			double num6 = num5 + num3 * 0.05;
			double num7 = num5 + num3 * 0.2;
			double num8 = num3 * 0.05;
			double num9 = num3 * 0.2;
			return num4 * (num6 * num8 + (num6 + num7) * (num8 + num9) + num7 * num9) / 6.0;
		}

		internal double Density(int Time)
		{
			double num = Volume(Time);
			double num2;
			if (num < 1E-12)
			{
				num2 = 0.0;
			}
			else
			{
				double num3 = 1.0;
				if ((double)(Time + 60) * 1.3 > (double)ReleaseAltitude)
				{
					double num4 = Volume((int)Math.Round((double)ReleaseAltitude / 1.3));
					num3 = num / num4;
				}
				num2 = BundlesPerMinute * DipolesPerBundle * num3 * 60.0 / 60.0 / num;
				if (num2 < 0.1)
				{
					num2 = 0.0;
				}
			}
			return num2;
		}

		internal bool IsEmpty(int Time)
		{
			if (Density(Time) < 1E-12)
			{
				return true;
			}
			return false;
		}

		internal int TopAltitude(int Time)
		{
			return (int)Math.Round(0.4 * (double)(Time + 60));
		}

		internal int BottomAltitude(int Time)
		{
			return Math.Min((int)Math.Round(1.3 * (double)(Time + 60)), 0);
		}

		internal double CloudLength(int Time)
		{
			return (60.0 * (double)AircraftSpeed * 1852.0 / 3600.0 + (double)(Time + 60) * 0.25 / 2.0) / 1852.0;
		}

		static TChaffCloud()
		{
			Class72.smethod_20();
		}
	}

	public enum RadarClutterType
	{
		None,
		Ground,
		Sea
	}

	public const string ModuleCredits = "Rodney Spence and Glenn Feldhake of NASA (propagation code)\r\nProf. David C. Jenn of NPS (radjam code)\r\nMicrowaves101 - phased array plot\r\nRaafat Nasser (U.S. Dept of Commerce) - RCG-44\r\nW.L.Patterson, C.P.Hattan, G.E.Lindem, Richard A.Paulus,  H.V.Hitney, K.D.Anderson, Amalia E.Barrios  - EREPS V.3.0 user manual. Tech.Doc.2648. San Diego, May 1994.\r\nAmalia E. Barrios, W. L. Patterson. - Advanced Propagation Model  Ver.1.3.1 CSCI Documents Tech.Doc.3145. San Diego, August 2002.\r\nAREPS User Manual V.3.6. San Diego, December 2006.\r\nHerr Alfred Ochs (Peter-Behrens-Str. 14, D-6100 Darmstadt) - the neat rain attenuation model from  the COST 210 Hydrometeor Scatter Prediction Procedure\r\nSources: ITU-R F.1245-1; ITU-R M.1652, miscellaneous files from ITU-R\r\nH.T.Dougherty, E.J.Dutton, 1981 NTIA Report 81-69\r\nRadar Technology Encyclopedia, 1998. David K. Barton, Sergey A. Leonov (eds.) \r\nKuzmin, 1974\r\nF.B.Chernyi. Rasprostranenie radiovoln. 2nd ed. M., 1972\r\nA.I.Kupriyanov, A.V.Sakharov. Teoreticheskiye osnovy radioelektronnoy borby. M., 2007\r\nYu.P.Melnikov. Vozdushnaya radiotekhnicheskaya razvedka. M., 2005\r\nV.G.Radzievsky (ed.) Sovremennaya radioelectronnaya borba. M., 2006\r\nA.I.Kanaschenkov, V.I.Merkulov (eds.) Zaschita radiolokatsionnykh sistem ot pomekh. M., 2003\r\nMichale O. Kolawole (2002) Radar Systems, Peak Detection and Tracking. Oxford, UK. 388 p.\r\nRadar Handbook (2nd and 3rd eds.) Edited by Merrill I. Skolnik.\r\nElectronic Warfare and Radar Systems Engineering Handbook\r\nV.I.Borisov, V.M.Zinchuk, A.E.Limarev. Pomekhozaschischennost' sistem radiosvyazi s rasshireniyem spektra signalov metodom PPRCh. M., 2008.";

	public const string ModuleVersion = "Version 2.03";

	public const double KW = 1000.0;

	public const double MHz = 1000000.0;

	public const double GHz = 1000000000.0;

	public static int NumberOfJammingTypes;

	public const double ThresholdSNR = 0.0;

	public const double ConstFalseAlarmRate = 1E-06;

	public const double ManualFalseAlarmRate = 0.001;

	public const double VoiceDetectabilityThresholdSNR = -15.8503;

	public const double ReflectionCoeff_Magnitude = 1.0;

	public const double ReflectionCoeff_PhaseLag = 3.14159265358979;

	private static double double_0;

	static RadarModel()
	{
		Class72.smethod_20();
		NumberOfJammingTypes = Enum.GetValues(typeof(TJammingType)).Length - 1;
		double_0 = 10.0 * Math.Log10(1.757026542415858E-09);
	}

	internal static bool ECM_Against_ECCM(TJammingType ECM, TECCMType ECCM)
	{
		int result;
		int result2;
		if (ECM > TJammingType.jt_Twinkling)
		{
			if (ECM > TJammingType.jt_Multiple_Synchronous_Pulse)
			{
				if (ECM > TJammingType.jt_Continuous)
				{
					if (ECM != TJammingType.jt_VGPO)
					{
						if (ECM != TJammingType.jt_RGPO)
						{
							goto IL_01e1;
						}
						if (ECCM <= TECCMType.et_Channel_Blanking)
						{
							if (ECCM <= TECCMType.et_Pulse_Front_End_Tracking)
							{
								switch (ECCM)
								{
								case TECCMType.et_Double_Pulse:
								case TECCMType.et_Rebroadcast_Delay_Detection:
								case TECCMType.et_Double_Pulse | TECCMType.et_Rebroadcast_Delay_Detection:
								case TECCMType.et_Two_Narrow_Guard_Strobes:
								case TECCMType.et_Single_Guard_Strobe:
								case TECCMType.et_Pulse_Front_End_Tracking:
									goto IL_01e5;
								}
								result = 0;
							}
							else if (ECCM > TECCMType.et_Asymmetric_Strobe_Front_End_Tracking)
							{
								if (ECCM == TECCMType.et_Pulse_Shortening || ECCM == TECCMType.et_Channel_Blanking)
								{
									goto IL_01e5;
								}
								result = 0;
							}
							else
							{
								if (ECCM == TECCMType.et_Pulse_Front_End_Extension || ECCM == TECCMType.et_Asymmetric_Strobe_Front_End_Tracking)
								{
									goto IL_01e5;
								}
								result = 0;
							}
						}
						else if (ECCM <= TECCMType.et_Double_Frequency_Concurrent)
						{
							if (ECCM <= TECCMType.et_Velocity_Maintenance_Logic)
							{
								if (ECCM == TECCMType.et_Velocity_Guard_Strobes || ECCM == TECCMType.et_Velocity_Maintenance_Logic)
								{
									goto IL_01e5;
								}
								result = 0;
							}
							else
							{
								if (ECCM == TECCMType.et_FFT_Spectrum_Analysis || ECCM == TECCMType.et_Double_Frequency_Concurrent)
								{
									goto IL_01e5;
								}
								result = 0;
							}
						}
						else if (ECCM <= TECCMType.et_Triple_Channel_Frequency_Discriminator)
						{
							if (ECCM == TECCMType.et_Double_Frequency_Consecutive || ECCM == TECCMType.et_Triple_Channel_Frequency_Discriminator)
							{
								goto IL_01e5;
							}
							result = 0;
						}
						else
						{
							if (ECCM == TECCMType.et_Correlated_Velocity_Range_Processing || ECCM == TECCMType.et_Steerable_Nulls)
							{
								goto IL_01e5;
							}
							result = 0;
						}
						goto IL_01e6;
					}
				}
				else if (ECM != TJammingType.jt_Chaotic_Pulse && ECM != TJammingType.jt_Continuous)
				{
					result2 = 0;
					goto IL_01e2;
				}
			}
			else if (ECM <= TJammingType.jt_Chaff_Illumination_Broadcast_Delay_Frequency_Shift)
			{
				if (ECM != TJammingType.jt_Chaff_Illumination_Broadcast_Delay && ECM != TJammingType.jt_Chaff_Illumination_Broadcast_Delay_Frequency_Shift)
				{
					result2 = 0;
					goto IL_01e2;
				}
			}
			else if (ECM != TJammingType.jt_Reflection_Spot && ECM != TJammingType.jt_Multiple_Synchronous_Pulse)
			{
				result2 = 0;
				goto IL_01e2;
			}
		}
		else
		{
			if (ECM <= TJammingType.jt_Cross_Polarization)
			{
				if (ECM > TJammingType.jt_Inverse_Jamming)
				{
					if (ECM == TJammingType.jt_Double_Frequency || ECM == TJammingType.jt_Cross_Polarization)
					{
						goto IL_01e5;
					}
					result2 = 0;
				}
				else
				{
					switch (ECM)
					{
					case (TJammingType)3:
						goto IL_01e1;
					case TJammingType.jt_Rebroadcast_Pulses_Azimouth_Shift:
					case TJammingType.jt_Rebroadcast_Pulses_Elevation_Shift:
					case TJammingType.jt_Rebroadcast_Pulses_Decrease:
					case TJammingType.jt_Inverse_Jamming:
						goto IL_01e5;
					}
					result2 = 0;
				}
				goto IL_01e2;
			}
			if (ECM > TJammingType.jt_Multistatic_Coherent)
			{
				if (ECM != TJammingType.jt_Multistatic_Incoherent && ECM != TJammingType.jt_Twinkling)
				{
					result2 = 0;
					goto IL_01e2;
				}
			}
			else if (ECM != TJammingType.jt_Mirror_Channel && ECM != TJammingType.jt_Multistatic_Coherent)
			{
				result2 = 0;
				goto IL_01e2;
			}
		}
		goto IL_01e5;
		IL_01e5:
		result = 0;
		goto IL_01e6;
		IL_01e1:
		result2 = 0;
		goto IL_01e2;
		IL_01e2:
		return (byte)result2 != 0;
		IL_01e6:
		return (byte)result != 0;
	}

	internal static bool RadarECMEquation(TRadar Radar, TTarget Target, int NumJammers, TJammer[] Jammers, double SlantDistanceToTarget, double[] SlantDistancesToJammers, double[] AzimouthsToJammers, Weather.WeatherProfile Env, RadarClutterType ClutterTypeToUse, GlobalVariables.TechGenerationClass SensorTechGeneration, double ChaffDensity = 0.0, double ChaffCloudThickness = 0.0, [Optional][DefaultParameterValue(null)] ref TRadar RadarReceiver, double ReceiverDistanceToTarget = 0.0, TSurfaceType TerrainType = TSurfaceType.st_Cropland, double MaxTerrainSlope = 0.0)
	{
		bool result;
		try
		{
			bool flag = false;
			if (RadarReceiver != null)
			{
				flag = true;
			}
			double[] array = new double[NumJammers - 1 + 1];
			int num;
			double num3;
			double num18;
			double num24;
			if (SlantDistanceToTarget <= 0.0)
			{
				result = false;
			}
			else if (!flag && SlantDistanceToTarget <= Radar.MinimumRangeNM)
			{
				result = false;
			}
			else
			{
				if (Radar.PulseWidth == 0.0 && Radar.ScanRate == 0.0)
				{
					throw new Exception("Zero pulsewidth and zero scanrate, cannot compute detection - illuminators not implemented");
				}
				if (Radar.AntennaGain == 0.0)
				{
					throw new Exception("Zero antenna gain, cannot compute detection");
				}
				if (Radar.HorzBeamWidth == 0.0)
				{
					num = 0;
					goto IL_08fa;
				}
				if (Radar.VertBeamWidth == 0.0)
				{
					num = 0;
					goto IL_08fa;
				}
				if (Radar.Frequency == 0.0)
				{
					throw new Exception("Zero frequency, cannot compute detection");
				}
				if (Radar.PulseWidth == 0.0)
				{
					throw new Exception("Zero pulse width, cannot compute detection");
				}
				if (Radar.PowerOutput == 0.0)
				{
					throw new Exception("Zero power output, cannot compute detection");
				}
				if (flag)
				{
					if (ReceiverDistanceToTarget <= 0.0)
					{
						throw new Exception("Receiver is ON target. Why use a radar at all - a good fuze is all you need!");
					}
					if (RadarReceiver.AntennaGain == 0.0)
					{
						throw new Exception("Zero RECEIVER antenna gain, cannot compute detection");
					}
					if (RadarReceiver.HorzBeamWidth == 0.0 || RadarReceiver.VertBeamWidth == 0.0)
					{
						throw new Exception("Zero RECEIVER beamwidth, cannot compute detection");
					}
				}
				double num2 = Math.Pow(10.0, Radar.AntennaGain / 10.0);
				num3 = 299792458.0 / Radar.Frequency;
				double dwellTime = Radar.GetDwellTime();
				double num4 = 1.0 / dwellTime;
				int num5 = NumJammers - 1;
				double num12 = default(double);
				double rangeKM;
				for (int i = 0; i <= num5; i++)
				{
					double num6 = Math.Pow(10.0, Jammers[i].Gain / 10.0);
					double num8;
					if (flag)
					{
						double angle = AzimouthsToJammers[i];
						double antennaGain = RadarReceiver.AntennaGain;
						double horzBeamWidth = RadarReceiver.HorzBeamWidth;
						TRadar tRadar;
						TSteerableNullSet SteerableNulls = (tRadar = RadarReceiver).SteerableNulls;
						double num7 = SinX_X_Pattern(angle, antennaGain, horzBeamWidth, ref SteerableNulls);
						tRadar.SteerableNulls = SteerableNulls;
						num8 = num7;
					}
					else
					{
						double angle2 = AzimouthsToJammers[i];
						double antennaGain2 = Radar.AntennaGain;
						double horzBeamWidth2 = Radar.HorzBeamWidth;
						TRadar tRadar;
						TSteerableNullSet SteerableNulls = (tRadar = Radar).SteerableNulls;
						double num9 = SinX_X_Pattern(angle2, antennaGain2, horzBeamWidth2, ref SteerableNulls);
						tRadar.SteerableNulls = SteerableNulls;
						num8 = num9;
					}
					double num10 = Math.Pow(10.0, num8 / 10.0);
					double num11;
					if (flag)
					{
						rangeKM = SlantDistancesToJammers[i] * 1852.0 / 1000.0;
						num11 = Math.Pow(10.0, PropagationLoss(RadarReceiver.Altitude, Jammers[i].Altitude, Radar.Frequency, RadarReceiver.VertBeamWidth, RadarReceiver.ElevationAngle, rangeKM, ref Env) / 10.0);
					}
					else
					{
						rangeKM = SlantDistancesToJammers[i] * 1852.0 / 1000.0;
						num11 = Math.Pow(10.0, PropagationLoss(Radar.Altitude, Jammers[i].Altitude, Radar.Frequency, Radar.VertBeamWidth, Radar.ElevationAngle, rangeKM, ref Env) / 10.0);
					}
					switch (Radar.RadarCalculations)
					{
					case TRadarCalcsType.rct_Simple_Pulsed:
						num12 = Jammers[i].Bandwidth / 1E-06;
						break;
					case TRadarCalcsType.rct_Integrated_Incoherent:
					case TRadarCalcsType.rct_Integrated_Coherent:
						num12 = Radar.HitsPerScan * (Jammers[i].Bandwidth / 1E-06);
						break;
					case TRadarCalcsType.rct_CW_Coherent:
						num12 = Jammers[i].Bandwidth / (Radar.ScanRate / 6.0);
						break;
					case TRadarCalcsType.rct_Synthetic_Aperture:
						num12 = Math.Sqrt(-1.0);
						break;
					}
					double num13 = Jammers[i].OutputW * num6 * num10 * (num4 / num12) / num11;
					array[i] = num13 / (1.380650424E-23 * num4);
				}
				double num14 = 0.0;
				int num15 = NumJammers - 1;
				for (int i = 0; i <= num15; i++)
				{
					if (array[i] > num14)
					{
						num14 = array[i];
					}
				}
				double num16 = (flag ? (RadarReceiver.AntennaTemp + RadarReceiver.ReceiverTemp + num14) : (Radar.AntennaTemp + Radar.ReceiverTemp + num14));
				double num17 = 1.380650424E-23 * num16 * num4;
				num18 = 1.0 * num17;
				double num19 = ((!flag) ? Math.Pow(10.0, Radar.ProcessingGain / 10.0) : Math.Pow(10.0, RadarReceiver.ProcessingGain / 10.0));
				double num20 = Math.Max(Target.Altitude, Target.Height);
				rangeKM = SlantDistanceToTarget * 1852.0 / 1000.0;
				double num23;
				if (flag)
				{
					double rangeKM2 = Math.Max(ReceiverDistanceToTarget, Geodesic_Vincenty.ApproxSlantRangeNM(ReceiverDistanceToTarget, RadarReceiver.Altitude, num20)) * 1852.0 / 1000.0;
					double num21 = PropagationLoss(Radar.Altitude, num20, Radar.Frequency, Radar.VertBeamWidth, Radar.ElevationAngle, rangeKM, ref Env);
					double num22 = PropagationLoss(RadarReceiver.Altitude, num20, Radar.Frequency, RadarReceiver.VertBeamWidth, RadarReceiver.ElevationAngle, rangeKM2, ref Env);
					double num11 = Math.Pow(10.0, (num21 + num22) / 10.0);
					num23 = Radar.PowerOutputW * (num2 * num2) * num19 * 4.0 * 3.14159265358979 / (num11 * (num3 * num3));
				}
				else
				{
					PropagationLoss(Radar.Altitude, num20, Radar.Frequency, Radar.VertBeamWidth, Radar.ElevationAngle, rangeKM, ref Env);
					double num11 = Math.Pow(10.0, FreeSpaceOneWayLoss(SlantDistanceToTarget * 1852.0 / 1000.0, Radar.FrequencyHz) / 10.0);
					num23 = Radar.PowerOutputW * (num2 * num2) * num19 * 4.0 * 3.14159265358979 / (num11 * num11 * (num3 * num3));
				}
				num24 = num23 * Target.RCS_m2;
				if (num18 > num24)
				{
					result = false;
				}
				else
				{
					if (ClutterTypeToUse == RadarClutterType.None)
					{
						goto IL_0887;
					}
					double num25 = 0.0 - Radar.ElevationAngle;
					if (num25 <= 0.0)
					{
						num25 = Math.Abs(num25);
					}
					double num26 = default(double);
					switch (ClutterTypeToUse)
					{
					case RadarClutterType.Sea:
						num26 = SeaClutterRCS(SlantDistanceToTarget, ref Radar, num20, Weather.WindFromSeaState(Env.SeaState), 45.0, ref Env, num25);
						break;
					case RadarClutterType.Ground:
					{
						double grazingAngle = num25;
						if (MaxTerrainSlope != 0.0)
						{
							double val = Math2.SlopePercentToDegrees(MaxTerrainSlope);
							grazingAngle = Math.Max(num25, val);
						}
						num26 = GroundClutterRCS(SlantDistanceToTarget, ref Radar, num20, TerrainType, ref Env, grazingAngle);
						break;
					}
					}
					double num27 = num23 * num26;
					if (SensorTechGeneration >= GlobalVariables.TechGenerationClass.const_7)
					{
						switch (SensorTechGeneration)
						{
						case GlobalVariables.TechGenerationClass.const_7:
							num27 *= 0.9025;
							break;
						case GlobalVariables.TechGenerationClass.const_8:
							num27 *= 0.81;
							break;
						case GlobalVariables.TechGenerationClass.const_9:
							num27 *= 0.6400000000000001;
							break;
						case GlobalVariables.TechGenerationClass.const_10:
							num27 *= 0.48999999999999994;
							break;
						case GlobalVariables.TechGenerationClass.const_11:
							num27 *= 0.36;
							break;
						case GlobalVariables.TechGenerationClass.const_12:
							num27 *= 0.25;
							break;
						case GlobalVariables.TechGenerationClass.const_13:
							num27 *= 0.16000000000000003;
							break;
						case GlobalVariables.TechGenerationClass.const_14:
							num27 *= 0.09;
							break;
						case GlobalVariables.TechGenerationClass.const_15:
							num27 *= 0.04000000000000001;
							break;
						case GlobalVariables.TechGenerationClass.const_16:
							num27 *= 0.010000000000000002;
							break;
						case GlobalVariables.TechGenerationClass.const_17:
							num27 *= 0.0025000000000000005;
							break;
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							break;
						}
					}
					if (Radar.SurfaceAndPeriscopeSearchCapability == TSurfaceAndPeriscopeSearchCapability.FineRangeResolution)
					{
						num27 /= 2.0;
					}
					else if (Radar.SurfaceAndPeriscopeSearchCapability == TSurfaceAndPeriscopeSearchCapability.AdvancedProcessing)
					{
						num27 /= 4.0;
					}
					if (!(num27 > num24))
					{
						goto IL_0887;
					}
					result = false;
				}
			}
			goto end_IL_0001;
			IL_08fa:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_0887:
			if (ChaffDensity > 0.0 && ChaffCloudThickness > 0.0)
			{
				double num28 = 0.73 * (num3 * num3) * ChaffDensity;
				num24 *= Math.Pow(10.0, -2.0 * num28 * ChaffCloudThickness * 1852.0 / 10.0);
			}
			result = !(num18 > num24);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101124", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num29;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num29 = 0;
			}
			else
			{
				num29 = 0;
			}
			result = (byte)num29 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static double SeaClutterRCS(double SlantDistanceToTarget, ref TRadar Radar, double TargetAlt, double WindSpeed, double AngleUpwind, ref Weather.WeatherProfile Env, double GrazingAngle)
	{
		double num = SurfaceClutterCellArea_dB(SlantDistanceToTarget, Radar.VertBeamWidth, Radar.HorzBeamWidth, Radar.PulseWidth, GrazingAngle);
		double num2 = SeaClutterRCSdB_RTE(ref Radar, SlantDistanceToTarget * 1852.0 / 1000.0, GrazingAngle, WindSpeed, AngleUpwind);
		return Math.Pow(10.0, (num2 + num) / 10.0);
	}

	internal static double GroundClutterRCS(double SlantDistanceToTarget, ref TRadar Radar, double TargetAlt, TSurfaceType SurfaceType, ref Weather.WeatherProfile Env, double GrazingAngle)
	{
		double num = SlantDistanceToTarget * 1852.0 * Radar.GetDwellTime() * 299792458.0 * 0.5 * Math.Tan(GrazingAngle * 0.0174532925199433);
		return LandReflectivity(ref Radar, SurfaceType, GrazingAngle) * num;
	}

	internal static bool smethod_0(IEmitter Emitter, TReceiver Receiver, double DistanceToEmitter, double AzimouthOffEmitterBoresight, Weather.WeatherProfile Env, [Optional][DefaultParameterValue(null)] ref IDoubleMatrix PropLossMatrix)
	{
		double antennaGain = Emitter.AntennaGain;
		double horzBeamWidth = Emitter.HorzBeamWidth;
		IEmitter emitter;
		TSteerableNullSet SteerableNulls = (emitter = Emitter).SteerableNulls;
		double num = SinX_X_Pattern(AzimouthOffEmitterBoresight, antennaGain, horzBeamWidth, ref SteerableNulls);
		emitter.SteerableNulls = SteerableNulls;
		double num2 = num;
		double num3 = 10.0 * Math.Log10(Emitter.PowerOutputW) + 30.0 + num2 - Receiver.Sensitivity - Receiver.SystemLoss;
		double rangeKM = Math.Max(DistanceToEmitter, Geodesic_Vincenty.ApproxSlantRangeNM(DistanceToEmitter, Emitter.Altitude, Receiver.Altitude)) * 1852.0 / 1000.0;
		if (PropagationLoss(Emitter.Altitude, Receiver.Altitude, Emitter.Frequency, Emitter.VertBeamWidth, Emitter.ElevationAngle, rangeKM, ref Env) > num3)
		{
			return false;
		}
		return true;
	}

	internal static int DataRateEquation(double Bandwidth, double SNR_dB)
	{
		return Floor(Bandwidth * Math.Log(1.0 + Math.Pow(10.0, SNR_dB / 10.0)) / Math.Log(2.0));
	}

	internal static double FreeSpaceRadarLoss(double Gain, double RCS, double RangeKm, double Frequency)
	{
		return -2.0 * Gain - 10.0 * Math.Log10(RCS) + 10.0 * Math.Log10(1984.4017075391823) + 40.0 * Math.Log10(RangeKm * 1000.0) + 20.0 * Math.Log10(Frequency) - 20.0 * Math.Log10(299792458.0);
	}

	internal static double RainAttenuation(double Frequency, double ElevationAngle, ref Weather.WeatherProfile Env)
	{
		return specific_atten_rain(Frequency, Env.RainfallRate, ElevationAngle, 0.0);
	}

	internal static double HeightAboveHorizon(double HRadar, double HShip, double DistanceNM, ref Weather.WeatherProfile Env)
	{
		double num = DistanceNM * 1852.0;
		double num2 = smethod_1(HRadar, 0.0, Env.DELTA_N) * 1000.0;
		double num3 = num2 / 6371000.0;
		_ = smethod_1(HShip, 0.0, Env.DELTA_N) * 1000.0 / 6371000.0;
		if (num > num2)
		{
			double num4 = Math.Tan(num / 6371000.0 - num3) * 6371000.0;
			double val = HShip - (Math.Sqrt(num4 * num4 + 40589641000000.0) - 6371000.0);
			return Math.Min(HShip, Math.Max(val, 0.0));
		}
		return HShip;
	}

	public static void ShipRCS(double HRadar, double HShip, double HDeck, double RCS_m2, double DistanceNM, ref Weather.WeatherProfile Env, ref double double_1, ref double RCS_Altitude)
	{
		if (HShip != 0.0 && HDeck != 0.0)
		{
			double num = HShip - HDeck;
			double_1 = RCS_m2;
			RCS_Altitude = num * 1.0 / 3.0 + HDeck;
		}
		else
		{
			double_1 = RCS_m2;
			RCS_Altitude = 0.0;
		}
	}

	internal static double SinX_X_Pattern(double Angle, double MaxGain, double BeamWidth, [Optional][DefaultParameterValue(null)] ref TSteerableNullSet SteerableNulls)
	{
		double num = Math.Abs(Angle);
		double result;
		if (num > 180.0)
		{
			result = MaxGain;
		}
		else if (num < 0.001)
		{
			result = MaxGain;
		}
		else
		{
			double num2 = 2.7831 * num / BeamWidth;
			double num3 = MaxGain + 20.0 * Math.Log10(Math.Abs(Math.Sin(num2) / num2));
			result = ((MaxGain < num3) ? MaxGain : num3);
			if (SteerableNulls != null && SteerableNulls.Angles.Length > 0)
			{
				int num4 = SteerableNulls.Angles.Length - 1;
				for (int i = 0; i <= num4; i++)
				{
					if (!(Math.Abs(Angle - SteerableNulls.Angles[i]) > SteerableNulls.Width / 2.0))
					{
						result = SteerableNulls.Level;
						break;
					}
				}
			}
		}
		return result;
	}

	internal static double ITU_R_F1245_Pattern(double Aperture, double Frequency, double eta, double Angle)
	{
		double num = 299792458.0 / Frequency;
		double num2 = Math.Abs(Angle);
		if (num2 < 1E-12)
		{
			num2 = 1E-05;
		}
		double num3 = 3.14159265358979 * Aperture / num;
		double num4 = 10.0 * Math.Log10(eta * num3 * num3);
		double num5 = Aperture / num;
		double num6 = num5 * num2;
		double val = num4 - 0.0025 * num6 * num6;
		double num7 = 2.0 + 15.0 * Math.Log(num5);
		double num8;
		double num9;
		double val2;
		if (num5 > 100.0)
		{
			num8 = 15.85 * Math.Pow(num5, -0.6);
			num9 = 10.0 * Math.Log(0.9 * Math.Pow(Math.Sin(4.7123889803847 * num2 / num8), 2.0) + 0.1);
			val2 = num7 + num9;
			if (num2 < num8)
			{
				return Math.Max(val, val2);
			}
			if (num2 < 48.0)
			{
				return 32.0 - 25.0 * Math.Log(num2) + num9;
			}
			return -10.0 + num9;
		}
		num8 = 39.8 * Math.Pow(num5, -0.8);
		num9 = 10.0 * Math.Log(0.9 * Math.Pow(Math.Sin(4.7123889803847 * num2 / num8), 2.0) + 0.1);
		val2 = num7 + num9;
		if (num2 < num8)
		{
			return Math.Max(val, val2);
		}
		if (num2 < 48.0)
		{
			return 42.0 - 5.0 * Math.Log(num5) - 25.0 * Math.Log(num2) + num9;
		}
		return -5.0 * Math.Log(num5) + num9;
	}

	internal static double ITU_R_M1652_Pattern(double MaxGain, double Angle)
	{
		double num = Math.Abs(Angle);
		if (num > 180.0)
		{
			throw new Exception("Angle out of limits");
		}
		double num2 = 50.0 * Math.Sqrt(0.25 * MaxGain + 7.0) / Math.Pow(10.0, MaxGain / 20.0);
		double num3;
		double num4;
		if (MaxGain > 48.0)
		{
			num3 = 27.466 * Math.Pow(10.0, -0.3 * MaxGain / 10.0);
			num4 = 48.0;
			if (num >= num4)
			{
				return -13.0;
			}
			if (num >= num3)
			{
				return 29.0 - 25.0 * Math.Log(num);
			}
			if (num >= num2)
			{
				return 0.75 * MaxGain - 7.0;
			}
			return MaxGain - 0.0004 * Math.Pow(10.0, MaxGain / 10.0) * (num * num);
		}
		num3 = 250.0 / Math.Pow(10.0, MaxGain / 20.0);
		if (MaxGain > 22.0)
		{
			num4 = 48.0;
			if (num >= num4)
			{
				return 11.0 - MaxGain / 2.0;
			}
			if (num >= num3)
			{
				return 53.0 - MaxGain / 2.0 - 25.0 * Math.Log(num);
			}
			if (num >= num2)
			{
				return 0.75 * MaxGain - 7.0;
			}
			return MaxGain - 0.0004 * Math.Pow(10.0, MaxGain / 10.0) * Math.Pow(num, 2.0);
		}
		num4 = 131.8257 * Math.Pow(10.0, (0.0 - MaxGain) / 50.0);
		if (num >= num4)
		{
			return 0.0;
		}
		if (num >= num3)
		{
			return 53.0 - MaxGain / 2.0 - 25.0 * Math.Log(num);
		}
		if (num >= num2)
		{
			return 0.75 * MaxGain - 7.0;
		}
		return MaxGain - 0.0004 * Math.Pow(10.0, MaxGain / 10.0) * Math.Pow(num, 2.0);
	}

	private static double smethod_1(double double_1, double double_2, double double_3 = 39.0)
	{
		double num = Weather.median_eff_Re(double_3) * 1000.0;
		double num2 = Math.Sqrt(2.0 * num * double_2 + double_2 * double_2);
		double num3 = Math.Sqrt(2.0 * num * double_1 + double_1 * double_1);
		return (Math.Atan(num2 / 6371000.0) + Math.Atan(num3 / 6371000.0)) * 6371.0;
	}

	internal static double SurfaceGrazingAngle_deg(double GroundRangeNM, double SrcH, double TgtH, ref Weather.WeatherProfile Env)
	{
		if (SrcH == 0.0 && TgtH == 0.0)
		{
			return 0.0;
		}
		double num = smethod_1(TgtH, SrcH, Env.DELTA_N) * 1000.0 / 1852.0;
		double num2 = 6371000.0 + SrcH;
		double num3 = num2 * num2;
		double d;
		double num4;
		if (GroundRangeNM >= num)
		{
			d = num * 1852.0 / 6371000.0;
			num4 = 6371000.0;
		}
		else
		{
			d = GroundRangeNM * 1852.0 / 6371000.0;
			num4 = 6371000.0 + TgtH;
		}
		double num5 = num4 * num4;
		double num6 = Math.Sqrt(num5 + num3 - 2.0 * num4 * num2 * Math.Cos(d));
		return Math.Acos((num6 * num6 + num5 - num3) / (2.0 * num6 * num4)) * 57.2957795130823 - 90.0;
	}

	internal static double GaseousAttenuation(double Frequency, double Pressure, double Temp, double RelativeHumidity)
	{
		double rho = Weather.RelativeHumidityToRho(RelativeHumidity, Temp);
		double num = specific_atten_dryair(Frequency / 1000000000.0, Pressure, Temp);
		double num2 = specific_atten_water(Frequency / 1000000000.0, Pressure, Temp, rho);
		return num + num2;
	}

	internal static int Floor(double X)
	{
		int num;
		try
		{
			num = (int)Math.Round(X);
			if (X - (double)num < 0.0)
			{
				num--;
			}
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
		return num;
	}

	internal static double g_specific_atten(double f, double fi)
	{
		double num = (f - fi) / (f + fi);
		return 1.0 + num * num;
	}

	internal static double specific_atten_water(double f, double pressure, double temp, double rho)
	{
		double num = pressure / 1013.0;
		double num2 = 288.0 / (273.0 + temp);
		double num3;
		double num4;
		double num5;
		if (f > 54.0)
		{
			num3 = 3.6 / ((f - 22.2) * (f - 22.2) + 8.5);
			num4 = 10.6 / ((f - 183.3) * (f - 183.3) + 9.0);
			num5 = 8.9 / ((f - 325.4) * (f - 325.4) + 26.3);
			return (0.05 + 0.021 * rho + num3 + num4 + num5) * (f * f) * rho * 0.0001;
		}
		double num6 = 0.955 * num * Math.Pow(num2, 0.68) + 0.006 * rho;
		double num7 = num2 * num2;
		double num8 = 0.735 * num * Math.Sqrt(num2) + 0.0353 * (num7 * num7) * rho;
		double num9 = num6 * num6;
		num3 = 3.98 * num6 * Math.Exp(2.23 * (1.0 - num2)) / ((f - 22.235) * (f - 22.235) + 9.42 * num9) * g_specific_atten(f, 22.0);
		num4 = 11.96 * num6 * Math.Exp(0.7 * (1.0 - num2)) / ((f - 183.31) * (f - 183.31) + 11.14 * num9);
		num5 = 0.081 * num6 * Math.Exp(6.44 * (1.0 - num2)) / ((f - 321.226) * (f - 321.226) + 6.29 * num9);
		double num10 = 3.66 * num6 * Math.Exp(1.6 * (1.0 - num2)) / ((f - 325.153) * (f - 325.153) + 9.22 * num9);
		double num11 = 25.37 * num6 * Math.Exp(1.09 * (1.0 - num2)) / ((f - 380.0) * (f - 380.0));
		double num12 = 17.4 * num6 * Math.Exp(1.46 * (1.0 - num2)) / ((f - 448.0) * (f - 448.0));
		double num13 = 844.6 * num6 * Math.Exp(0.17 * (1.0 - num2)) / ((f - 557.0) * (f - 557.0)) * g_specific_atten(f, 557.0);
		double num14 = 290.0 * num6 * Math.Exp(0.41 * (1.0 - num2)) / ((f - 752.0) * (f - 752.0)) * g_specific_atten(f, 752.0);
		double num15 = 83328.0 * num8 * Math.Exp(0.99 * (1.0 - num2)) / ((f - 1780.0) * (f - 1780.0)) * g_specific_atten(f, 1780.0);
		return (num3 + num4 + num5 + num10 + num11 + num12 + num13 + num14 + num15) * (f * f) * Math.Pow(num2, 2.5) * rho * 0.0001;
	}

	internal static double psi_specific_atten(double rp, double rt, double a, double b, double c, double D)
	{
		return Math.Pow(rp, a) * Math.Pow(rt, b) * Math.Exp(c * (1.0 - rp) + D * (1.0 - rt));
	}

	internal static double specific_atten_dryair(double f, double pressure, double temp)
	{
		double num = pressure / 1013.0;
		double num2 = 288.0 / (273.0 + temp);
		double num3 = f * f;
		double num4;
		double num5;
		if (f <= 54.0)
		{
			num4 = psi_specific_atten(num, num2, 0.0717, -1.8132, 0.0156, -1.6515);
			num5 = psi_specific_atten(num, num2, 0.5146, -4.6368, -0.1921, -5.7416);
			double num6 = psi_specific_atten(num, num2, 0.3414, -6.5851, 0.213, -8.5854);
			double num7 = num * num;
			return (7.2 * Math.Pow(num2, 2.8) / (num3 + 0.34 * num7 * Math.Pow(num2, 1.6)) + 0.62 * num6 / (Math.Pow(54.0 - f, 1.16 * num4) + 0.83 * num5)) * num3 * num7 * 0.001;
		}
		num4 = 6.09 / (num3 + 0.227);
		num5 = 4.81 / ((f - 57.0) * (f - 57.0) + 1.5);
		return (1.0 + 0.01 * (temp - 15.0)) * 0.001 * (num4 + num5 + 0.00719) * num3;
	}

	public static void NATOBand_Freqs(string BandName, ref TNATORadarBand Band)
	{
		switch (BandName)
		{
		case "L Band":
			Band.LoFreq = 40000000000.0;
			Band.HiFreq = 60000000000.0;
			break;
		case "J Band":
			Band.LoFreq = 10000000000.0;
			Band.HiFreq = 20000000000.0;
			break;
		case "D Band":
			Band.LoFreq = 1000000000.0;
			Band.HiFreq = 2000000000.0;
			break;
		case "A Band":
			Band.LoFreq = 0.0;
			Band.HiFreq = 250000000.0;
			break;
		case "C Band":
			Band.LoFreq = 500000000.0;
			Band.HiFreq = 1000000000.0;
			break;
		case "M Band":
			Band.LoFreq = 60000000000.0;
			Band.HiFreq = 100000000000.0;
			break;
		case "I Band":
			Band.LoFreq = 8000000000.0;
			Band.HiFreq = 10000000000.0;
			break;
		case "F Band":
			Band.LoFreq = 3000000000.0;
			Band.HiFreq = 4000000000.0;
			break;
		case "G Band":
			Band.LoFreq = 4000000000.0;
			Band.HiFreq = 6000000000.0;
			break;
		case "H Band":
			Band.LoFreq = 6000000000.0;
			Band.HiFreq = 8000000000.0;
			break;
		case "E Band":
			Band.LoFreq = 2000000000.0;
			Band.HiFreq = 3000000000.0;
			break;
		case "K Band":
			Band.LoFreq = 20000000000.0;
			Band.HiFreq = 40000000000.0;
			break;
		default:
			throw new Exception("Unsupported band name");
		case "B Band":
			Band.LoFreq = 250000000.0;
			Band.HiFreq = 500000000.0;
			break;
		}
		Band.DefaultFreq = (Band.LoFreq + Band.HiFreq) / 2.0;
	}

	internal static double SeaClutterPower(ref TRadar Radar, double RangeKM, double LaunchAnglePatternFactor, double GrazingAngle, double WindSpeed_ms, double AngleToUpwind)
	{
		double num = 299792458.0 / Radar.Frequency;
		double num2 = Math.Pow(1.9425 * WindSpeed_ms / (1.0 + WindSpeed_ms / 15.0), 1.1 * Math.Pow(num + 0.02, -0.4));
		double num3 = Math.Pow(WindSpeed_ms / 8.67, 2.5);
		double x = (14.4 * num + 5.5) * GrazingAngle * num3 / (num + 0.02);
		double num4 = Math.Pow(x, 4.0) / (1.0 + Math.Pow(x, 4.0));
		double num5 = Math.Exp(0.2 * Math.Cos(AngleToUpwind) * (1.0 - 2.8 * GrazingAngle) * Math.Pow(num + 0.02, -0.4));
		double num6 = 10.0 * Math.Log10(1000.0 * RangeKM * 0.0174532925199433 * Radar.HorzBeamWidth * Radar.GetDwellTime() / (4.0 * Math.Log(2.0)));
		double num7 = 10.0 * Math.Log10(3.9E-06 * num * Math.Pow(GrazingAngle, 0.4) * num4 * num5 * num2) + num6;
		return -123.0 + 10.0 * Math.Log10(Radar.PowerOutputW / 1000.0 * (num * num) * Math.Pow(LaunchAnglePatternFactor, 4.0) / Math.Pow(RangeKM, -4.0)) + 2.0 * Radar.AntennaGain + num7 + Radar.ProcessingGain;
	}

	internal static double SeaClutterRCSdB(ref TRadar Radar, double RangeKM, double GrazingAngleDegrees, double WindSpeed_ms, double AngleToUpwind)
	{
		double num = GrazingAngleDegrees * 100.0 * 0.0174532925199433;
		double num2 = 299792458.0 / Radar.Frequency;
		double num3 = Math.Pow(1.9425 * WindSpeed_ms / (1.0 + WindSpeed_ms / 15.0), 1.1 * Math.Pow(num2 + 0.02, -0.4));
		Math.Pow(WindSpeed_ms / 8.67, 2.5);
		double num4 = SeaRoughnessFromWind(WindSpeed_ms, Radar.Frequency, GrazingAngleDegrees);
		double num5 = Math.Exp(0.2 * Math.Cos(AngleToUpwind) * (1.0 - 2.8 * num) * Math.Pow(num2 + 0.02, -0.4));
		double num6 = 10.0 * Math.Log10(1000.0 * RangeKM * 0.0174532925199433 * Radar.HorzBeamWidth * Radar.GetDwellTime() / (4.0 * Math.Log(2.0)));
		double num7 = ((num4 != 0.0) ? (10.0 * Math.Log10(3.9E-06 * num2 * Math.Pow(num, 0.4) * num4 * num5 * num3)) : 0.0);
		return num7 + num6;
	}

	internal static double SeaClutterRCSdB_RTE(ref TRadar Radar, double RangeKM, double GrazingAngleDegrees, double WindSpeed_ms, double AngleToUpwind)
	{
		double num;
		if (GrazingAngleDegrees == 0.0)
		{
			num = 0.0;
		}
		else
		{
			double num2 = GrazingAngleDegrees * 0.0174532925199433;
			double num3 = 299792458.0 / Radar.Frequency;
			double num4 = Math.Pow(WindSpeed_ms, 2.0 / 3.0) / 0.836;
			double num5 = num4 * num4 * num4 / 300.0;
			double num6 = ((num5 != 0.0) ? Math.Min(1.5707963267949, Math.Asin(num3 / (12.56637061435916 * num5))) : 1.5707963267949);
			double num7 = 6.0 * num4 + 10.0 * Math.Log10(num3) - 64.0;
			double num8 = Math.Pow(10.0, num7 / 10.0);
			double num10;
			if (num2 <= num6)
			{
				double num9 = num2 / num6;
				num9 *= num9;
				num9 *= num9;
				num10 = Math.Log10(num8 * num2 * num9) * 10.0;
			}
			else
			{
				num10 = Math.Log10(num8 * Math.Sin(num2)) * 10.0;
			}
			num = num10;
			if (double.IsNaN(num))
			{
				num = 0.0;
			}
		}
		return num;
	}

	internal static double LandReflectivity(ref TRadar Radar, TSurfaceType Surface, double GrazingAngle)
	{
		double num = GrazingAngle * 0.0174532925199433;
		double num2 = 299792458.0 / Radar.Frequency;
		double num3;
		double num4;
		switch (Surface)
		{
		default:
			throw new Exception("Unsupported surface type");
		case TSurfaceType.st_Urban:
			num3 = -5.0;
			num4 = 10.0;
			break;
		case TSurfaceType.st_Mountains:
			num3 = -5.0;
			num4 = 100.0;
			break;
		case TSurfaceType.st_Cropland:
			num3 = -10.0;
			num4 = 3.0;
			break;
		case TSurfaceType.st_Shrubland:
			num3 = -12.0;
			num4 = 5.0;
			break;
		case TSurfaceType.st_Forest:
			num3 = -15.0;
			num4 = 10.0;
			break;
		case TSurfaceType.st_Desert:
			num3 = -20.0;
			num4 = 3.0;
			break;
		case TSurfaceType.st_Tundra:
		case TSurfaceType.st_Grassland:
		case TSurfaceType.st_Wetland:
			num3 = -20.0;
			num4 = 1.0;
			break;
		}
		double num5 = Math.Pow(10.0, num3 / 10.0);
		double num6 = ((num4 != 0.0) ? Math.Min(1.5707963267949, Math.Asin(num2 / (12.56637061435916 * num4))) : 1.5707963267949);
		double num8;
		if (num <= num6)
		{
			double num7 = num / num6;
			num7 *= num7;
			num7 *= num7;
			num8 = Math.Log10(num5 * num * num7) * 10.0;
		}
		else
		{
			num8 = Math.Log10(num5 * Math.Sin(num)) * 10.0;
		}
		return Math.Pow(10.0, num8 / 10.0);
	}

	internal static double DiffractionZoneRangeKM(ref TMetricParams MP, ref Weather.WeatherProfile Env)
	{
		double num = Math.Max(1.3333333333333333, Env.k50);
		return 3.572 * (Math.Sqrt(num * MP.h1) + Math.Sqrt(num * MP.h2)) + 230.2 * Math.Pow(num * num / MP.Frequency, 1.0 / 3.0);
	}

	internal static double FreeSpaceOneWayLoss(double r, double Frequency)
	{
		return double_0 + 20.0 * Math.Log10(r) + 20.0 * Math.Log10(Frequency);
	}

	public static void dconst(double Frequency, ref TEvapDuctParams Params, ref Weather.WeatherProfile Env)
	{
		double num = Frequency / 1000000.0;
		double num2 = num * num;
		double num3 = num * num2;
		double num4 = num2 * num2;
		double num5 = Math.Pow(num, 1.0 / 3.0);
		double num6 = 70.0;
		if (num > 2253.5895)
		{
			num6 = 1.0 / (0.014114535 + -5.2122497E-08 * num + 5.8547829E-11 * num2 + -7.6717423E-16 * num3 + 2.9856318E-21 * num4);
		}
		double num7 = 5.0;
		if (num > 1106.207)
		{
			num7 = 3.8586749 + 0.00091253873 * num + 1.5309921E-08 * num2;
			num7 /= 1.0 + -2.1179295E-05 * num + 6.5727504E-10 * num2 + -1.9647664E-15 * num3;
		}
		double num8 = num6;
		double num9 = -18000.0 * num7 / num;
		double num10 = Math.Pow(Env.RadiusEffective, 1.0 / 3.0);
		double num11 = num9 * num9;
		double num12 = Math.Pow(20.943951023931934, -1.0 / 3.0) / (num10 * num5);
		double x = (num8 - 1.0) * (num8 - 1.0) + num11;
		double capk = num12 / Math.Pow(x, 0.25);
		Params.capk = capk;
		Params.xterm = 2.2 * num5 / (num10 * num10);
		Params.zterm = 0.0096 * (num5 * num5) / num10;
		if (Env.EvaporationDuctHeight == 0.0)
		{
			Params.del = 0.0;
			return;
		}
		Params.rfac = Math.Pow(num / 9600.0, 1.0 / 3.0);
		Params.zfac = Math.Pow(num / 9600.0, 2.0 / 3.0);
		Params.hmin = 1.0;
		Params.del = Env.EvaporationDuctHeight * Params.zfac;
		if (Params.del > 23.3)
		{
			Params.del = 23.3;
		}
		if (Params.del >= 10.25)
		{
			Params.C1 = -0.1189 * Params.del + 5.5495;
			Params.C3 = 1.5;
			Params.C2 = 1.3291 * Math.Sin(0.218 * Math.Pow(Params.del - 10.0, 0.77)) + 0.2171 * Math.Log(Params.del);
			Params.C2 *= Math.Pow(4.72, 0.0 - Params.C3);
			Params.C4 = 87.0 - Math.Sqrt(313.29 - (Params.del - 25.3) * (Params.del - 25.3));
			Params.zmax = 4.0 * Math.Exp(-0.31 * (Params.del - 10.0)) + 6.0;
			double a = Params.C2 * Math.Pow(Params.zmax, Params.C3);
			double num13 = 4.72 * Params.C1 * Params.C2 * Params.C3 * Math.Sqrt(Params.zmax) / Math.Tan(a);
			Params.C7 = 49.4 * Math.Exp(-0.1699 * (Params.del - 10.0)) + 30.0;
			double num14 = Params.C1 * Math.Log(Math.Sin(a)) + Params.C4 - Params.C7;
			Params.C6 = Params.zmax / 4.72 * num13 / num14;
			Params.C5 = num14 / Math.Pow(Params.zmax, Params.C6);
		}
		else
		{
			Params.C2 = Math.Sqrt(40623.61 - (Params.del + 4.4961) * (Params.del + 4.4961)) - 201.0128;
			Params.C1 = (-2.2 * Math.Exp(-0.244 * Params.del) + 17.0) * Math.Pow(4.72, 0.0 - Params.C2);
			Params.C4 = Math.Sqrt(14301.2 - (Params.del + 5.32545) * (Params.del + 5.32545)) - 119.569;
			Params.C3 = (-33.9 * Math.Exp(-0.5170001 * Params.del) - 3.0) * Math.Pow(4.72, 0.0 - Params.C4);
			Params.C5 = 41.0 * Math.Exp(-0.41 * Params.del) + 61.0;
		}
		Params.atten = 92.516 - Math.Sqrt(8608.7593 - (Params.del - 20.2663) * (Params.del - 20.2663));
		if (Params.atten < 0.0009)
		{
			Params.atten = 0.0009;
		}
		Params.atten *= Params.rfac;
		double num15 = default(double);
		if (Params.del <= 3.8)
		{
			num15 = 216.7 + Params.del * 1.5526;
		}
		if (Params.del > 3.8)
		{
			num15 = 222.6 - (Params.del - 3.8) * 1.1771;
		}
		Params.difac = 51.1 + num15 + 10.0 * Math.Log10(Params.rfac);
	}

	public static void hgain(double h, ref double SBD_Gain_dB, ref double ED_Gain_dB, double Frequency, TEvapDuctParams EDP, ref Weather.WeatherProfile Env)
	{
		double num = Frequency / 1000000.0;
		SBD_Gain_dB = 0.0;
		ED_Gain_dB = 0.0;
		if (Env.SurfaceDuctHeight > 0.0)
		{
			double num2 = h / Env.SurfaceDuctHeight;
			if (num <= 150.0 && num2 < 0.8)
			{
				SBD_Gain_dB = -60.0 * Math.Pow(num2 - 0.5, 2.0);
			}
			if (num <= 150.0 && num2 >= 0.8)
			{
				SBD_Gain_dB = 1.14 * Math.Pow(num2, -6.26) - 10.0;
			}
			if (num > 150.0 && num2 < 1.0)
			{
				SBD_Gain_dB = 10.0 - 200.0 * Math.Pow(num2 - 0.5, 4.0);
			}
			if (num > 150.0 && num <= 350.0 && num2 >= 1.0)
			{
				SBD_Gain_dB = 7.5 * Math.Pow(num2, -13.3) - 10.0;
			}
			if (num > 350.0 && num2 >= 1.0)
			{
				SBD_Gain_dB = 12.5 * Math.Pow(num2, -8.0) - 15.0;
			}
		}
		if (!(EDP.del > 0.0))
		{
			return;
		}
		double num3 = h * EDP.zfac;
		if (num3 < EDP.hmin)
		{
			num3 = EDP.hmin;
		}
		if (EDP.del >= 10.25)
		{
			if (num3 > EDP.zmax)
			{
				ED_Gain_dB = EDP.C5 * Math.Pow(num3, EDP.C6) + EDP.C7;
			}
			else
			{
				ED_Gain_dB = EDP.C1 * Math.Log(Math.Sin(EDP.C2 * Math.Pow(num3, EDP.C3))) + EDP.C4;
			}
		}
		else
		{
			ED_Gain_dB = EDP.C1 * Math.Pow(num3, EDP.C2) + EDP.C3 * Math.Pow(num3, EDP.C4) + EDP.C5;
		}
	}

	internal static double DiffRgnHeightGain(double z, ref TEvapDuctParams EDP)
	{
		double num;
		if (z > 2.0)
		{
			num = 17.6 * Math.Sqrt(z - 1.1) - 2.1715 * Math.Log(z - 1.1) - 8.0;
		}
		else if (z > 10.0 * EDP.capk)
		{
			num = 20.0 * Math.Log10(z + 0.1 * z * z * z);
		}
		else
		{
			num = 2.0 + 20.0 * Math.Log10(EDP.capk);
			if (z > EDP.capk / 10.0)
			{
				double num2 = 0.1 * Math.Log10(z / EDP.capk);
				num += 9.0 * num2 * (num2 + 1.0);
			}
		}
		return num;
	}

	internal static double IntermediateRegionPF(ref TMetricParams MP, double DiffractionRange, ref TEvapDuctParams EDP, ref TOpticalParams OP, ref Weather.WeatherProfile Env)
	{
		double num = 32.45 + 20.0 * Math.Log10(MP.Frequency / 1000000.0);
		double num2 = num + 20.0 * Math.Log10(MP.range);
		double num3 = DiffractionLoss(ref MP, ref EDP, ref Env, OP.exloss);
		num3 = num3 - num - 20.0 * Math.Log10(DiffractionRange);
		double num4 = (MP.range - OP.opmaxd) * (OP.opmaxl - num3) / (OP.opmaxd - DiffractionRange);
		double num5 = OP.opmaxl + num4;
		if (Env.SurfaceDuctHeight > 0.0 && Env.SurfaceDuctHeight >= MP.h1)
		{
			double num6 = num5 + num2;
			double num7 = SurfaceDuctLoss(ref MP, ref OP, ref EDP, ref Env, OP.exloss);
			if (num7 < num6)
			{
				num6 = num7;
			}
			num5 = num6 - num2;
		}
		return num5;
	}

	internal static double DiffractionLoss(ref TMetricParams MP, ref TEvapDuctParams EDP, ref Weather.WeatherProfile Env, double exloss)
	{
		double num = 32.45 + 20.0 * Math.Log10(MP.Frequency / 1000000.0);
		double num2 = DiffRgnHeightGain(EDP.zterm * MP.h1, ref EDP);
		double num3 = DiffRgnHeightGain(EDP.zterm * MP.h2, ref EDP);
		double num4 = num - num2 - num3;
		double num5 = 10.0 * Math.Log10(MP.range);
		double num6 = EDP.xterm * MP.range;
		double num7 = 11.0 + 10.0 * Math.Log10(num6) - 17.6 * num6;
		double num8 = num4 + 2.0 * num5 - num7;
		if (Env.EvaporationDuctHeight != 0.0)
		{
			double num9 = EDP.difac + num5 + EDP.atten * MP.range;
			if (num9 < num8)
			{
				num8 = num9;
			}
		}
		num8 += exloss;
		double num10 = TroposcatterLoss(ref MP, exloss, ref Env);
		double num11 = num8 - num10;
		if (num11 >= 18.0)
		{
			num8 = num10;
		}
		else if (num11 >= -18.0)
		{
			num8 -= 10.0 * Math.Log10(1.0 + Math.Exp(Math.Log(10.0) * num11 / 10.0));
		}
		return num8;
	}

	internal static double TroposcatterLoss(ref TMetricParams MP, double exloss, ref Weather.WeatherProfile Env)
	{
		double num = MP.Frequency / 1000000.0 * (MP.Frequency / 1000000.0) * (MP.Frequency / 1000000.0);
		double num2 = 0.031 - 0.00232 * Env.SurfaceRefractivity + 5.67E-06 * Env.SurfaceRefractivity * Env.SurfaceRefractivity;
		double num3 = MP.h1 * 0.0419 * MP.Frequency / 1000000.0;
		double num4 = MP.h2 * 0.0419 * MP.Frequency / 1000000.0;
		double num5 = 0.08984 / Env.k50;
		double num6 = 0.2 * Env.SurfaceRefractivity;
		double num7 = smethod_1(MP.h1, MP.h2, Env.DELTA_N);
		double num8 = Math.Sqrt(MP.h1 * Env.RadiusEffective / 500.0) / Env.RadiusEffective;
		double num9 = Math.Sqrt(MP.h2 * Env.RadiusEffective / 500.0) / Env.RadiusEffective;
		double num10 = MP.range / Env.RadiusEffective;
		double num11 = num10 - num8 - num9;
		double num12 = num10 / 2.0 - num8 + (MP.h1 - MP.h2) / (1000.0 * MP.range);
		double num13 = num10 / 2.0 - num9 + (MP.h2 - MP.h1) / (1000.0 * MP.range);
		double num14 = num3 * num11;
		double num15 = num4 * num11;
		if (num14 < 0.1)
		{
			num14 = 0.1;
		}
		if (num15 < 0.1)
		{
			num15 = 0.1;
		}
		double num16 = num12 / num13;
		if (num16 > 10.0)
		{
			num16 = 10.0;
		}
		if (num16 < 0.1)
		{
			num16 = 0.1;
		}
		double num17 = num15 / (num16 * num14);
		if (num17 > 10.0)
		{
			num17 = 10.0;
		}
		if (num17 < 0.1)
		{
			num17 = 0.1;
		}
		double num18 = num16 * MP.range * num11 / ((1.0 + num16) * (1.0 + num16));
		double num19 = num18 * num18 * num18;
		double num20 = 0.5696 * num18 * (1.0 + num2 * Math.Exp(-3.8E-06 * (num19 * num19)));
		if (num20 > 5.0)
		{
			num20 = 5.0;
		}
		if (num20 < 0.01)
		{
			num20 = 0.01;
		}
		double num21 = 16.3 + 13.3 * num20;
		double num22 = 0.4 + 0.16 * num20;
		double num23 = num21 * Math.Pow(num14 + num22, -1.333);
		double num24 = num21 * Math.Pow(num15 + num22, -1.333);
		double num25 = (num23 + num24) / 2.0;
		double num26 = 1.13 * (0.6 - 0.1 * Math.Log10(num20)) * Math.Log(num16) * Math.Log(num17);
		num25 = ((!(num26 > num25)) ? (num25 + num26) : (2.0 * num25));
		if (num25 < 0.0)
		{
			num25 = 0.0;
		}
		return 114.9 + num5 * (MP.range - num7) + 10.0 * Math.Log10(MP.range * MP.range * num) - num6 + num25 + exloss;
	}

	internal static double SurfaceDuctLoss(ref TMetricParams MP, ref TOpticalParams OP, ref TEvapDuctParams EDP, ref Weather.WeatherProfile Env, double exloss)
	{
		if (Env.SurfaceDuctHeight != 0.0 && MP.h2 <= Env.SurfaceDuctHeight)
		{
			double num = 32.45 + 20.0 * Math.Log10(MP.Frequency / 1000000.0);
			double rsbd = default(double);
			double rsbdloss = default(double);
			double SBD_Gain_dB = default(double);
			skipzone(ref MP, ref OP, ref rsbd, ref rsbdloss, ref SBD_Gain_dB, num, EDP, Env);
			if (MP.range < rsbd)
			{
				return rsbdloss + (rsbd - MP.range) + exloss;
			}
			return num + 20.0 * Math.Log10(MP.range) - SBD_Gain_dB + exloss;
		}
		return 1000.0;
	}

	internal static double OpticalPathLengthDifference(double Frequency, double RangeKm, double ht, double hr, ref Weather.WeatherProfile Env)
	{
		double x = default(double);
		double num = ht - 1000.0 * Math.Pow(x, 2.0) / (2.0 * Env.RadiusEffective);
		double x2 = default(double);
		double num2 = hr - 1000.0 * Math.Pow(x2, 2.0) / (2.0 * Env.RadiusEffective);
		double num3 = Math.Sqrt(1.3333333333333333 * (0.001 * Env.RadiusEffective * (ht + hr) + Math.Pow(RangeKm, 2.0) / 4.0));
		double num4 = Math.Acos(0.002 * Env.RadiusEffective * Math.Abs(ht - hr) * RangeKm / num3);
		x = RangeKm / 2.0 - num3 * Math.Cos((num4 + 3.14159265358979) / 3.0);
		x2 = RangeKm - x;
		double result = 6.28318530717958 * (2.0 * num * num2 / (1000.0 * RangeKm * 299792458.0 / Frequency));
		_ = 0.001 * Math.Abs(ht - hr) / RangeKm;
		_ = 0.001 * Math.Min(num, num2) / Math.Min(x, x2);
		return result;
	}

	internal static double GetTheta(double r1, double h1, double h2, double Frequency, ref Weather.WeatherProfile Env)
	{
		double num = h1 - r1 * r1 * 1000.0 / (2.0 * Env.RadiusEffective);
		double num2 = 12.56637061435916 * Frequency * 1000.0 / 299792458.0;
		double num3 = num / r1;
		if (0.001 * num3 > 0.05236)
		{
			Math.Atan(0.001 * num / r1);
		}
		double num4 = h2 * 4.0 * 1000.0 / (2.0 * Env.RadiusEffective);
		double num5 = (Math.Sqrt(num3 * num3 + num4) - num3) * (Env.RadiusEffective / 1000.0);
		double num6 = r1 + num5;
		double num7 = h2 - num5 * num5 / (2.0 * Env.RadiusEffective / 1000.0);
		return 3.14159265358979 + num2 * num * num7 / num6;
	}

	internal static double r1iter(double rtheta, double r1_0, double h1, double h2, double Frequency, ref Weather.WeatherProfile Env)
	{
		int num = 0;
		double num2 = r1_0;
		double num3 = r1_0;
		double num4 = smethod_1(h1, 0.0, Env.DELTA_N);
		while (!(Math.Abs(num2) <= 0.001) && num < 5)
		{
			double theta = GetTheta(num3, h1, h2, Frequency, ref Env);
			double num5 = (GetTheta(num3 + 0.001, h1, h2, Frequency, ref Env) - theta) / 0.001;
			if (num5 == 0.0)
			{
				num5 = 1E-08;
			}
			num2 = (rtheta - theta) / num5;
			num++;
			num3 = ((!(num2 > 0.0 - num3)) ? (num3 / 2.0) : ((!(num2 + num3 > num4)) ? (num3 + num2) : ((num3 + num4) / 2.0)));
		}
		return num3;
	}

	internal static double PropagationLoss(double h1, double h2, double Frequency, double VertBeamWidth, double Elevation, double RangeKM, ref Weather.WeatherProfile Env)
	{
		return FreeSpaceOneWayLoss(RangeKM, Frequency);
	}

	public static void oplimit(ref TOpticalParams OptParams, ref TMetricParams MP, ref TEvapDuctParams EDP, ref Weather.WeatherProfile Env, ref TAntennaParams AP)
	{
		double num = 0.01957 / Math.Pow(Env.k50 * MP.Frequency / 1000000.0, 1.0 / 3.0);
		double num2 = 1000.0 * num;
		double num3 = (Math.Sqrt(num2 * num2 + MP.h1 * 4.0 / (Env.RadiusEffective / 1000.0 * (Env.RadiusEffective / 1000.0))) - num2) * (Env.RadiusEffective / 1000.0);
		OptParams.r1min = 0.01 * MP.range * MP.h1 / (MP.h1 + MP.h2);
		double r1_ = num3;
		r1_ = r1iter(4.712388980384685, r1_, MP.h1, MP.h2, MP.Frequency, ref Env);
		if (num3 > r1_)
		{
			r1_ = num3;
		}
		num3 = r1_;
		if (num3 < OptParams.r1min)
		{
			OptParams.r1min = num3 / 2.0;
		}
		double theta2;
		if (EDP.del > 0.0)
		{
			double theta = GetTheta(num3, MP.h1, MP.h2, MP.Frequency, ref Env);
			theta2 = GetTheta(OptParams.r1min, MP.h1, MP.h2, MP.Frequency, ref Env);
			double num4 = Math.Min(theta2, 6.28318530717958);
			theta = ((!(EDP.del < 10.25)) ? num4 : (theta + EDP.del / 10.25 * (num4 - theta)));
			num3 = r1iter(theta, num3, MP.h1, MP.h2, MP.Frequency, ref Env);
		}
		r1_ = num3;
		theta2 = GetTheta(r1_, MP.h1, MP.h2, MP.Frequency, ref Env);
		double num5 = MP.h1 - r1_ * r1_ * 1000.0 / (2.0 * Env.RadiusEffective);
		num2 = num5 / r1_;
		if (0.001 * num2 > 0.05236)
		{
			Math.Atan(0.001 * num5 / r1_);
		}
		double num6 = MP.h2 * 4.0 * 1000.0 / (2.0 * Env.RadiusEffective);
		double num7 = (Math.Sqrt(num2 * num2 + num6) - num2) * (Env.RadiusEffective / 1000.0);
		OptParams.opmaxd = r1_ + num7;
		double gamma = ((!(MP.h2 >= MP.h1)) ? (r1_ / Env.RadiusEffective) : (num7 / Env.RadiusEffective));
		double patd = default(double);
		double dr = default(double);
		opffac(gamma, MP.Frequency, OptParams.opmaxd, MP.h1, MP.h2, r1_, num7, ref patd, ref dr, ref Env, ref AP);
		double num8 = patd * patd + dr * dr + 2.0 * dr * patd * Math.Cos(theta2);
		if (num8 < 1E-07)
		{
			num8 = 1E-07;
		}
		OptParams.opmaxl = -10.0 * Math.Log10(num8);
		OptParams.exloss = -20.0 * Math.Log10(patd);
	}

	internal static double opticf(ref TMetricParams MP, ref TOpticalParams OP, ref TAntennaParams AP, ref Weather.WeatherProfile Env)
	{
		double num = 12.56637061435916 * MP.Frequency * 1000.0 / 299792458.0;
		double num2 = MP.h1 / (MP.h1 + MP.h2) * MP.range;
		double num3 = -1.5 * MP.range;
		double num4 = 0.5 * Math.Pow(MP.range, 2.0) - Env.RadiusEffective / 1000.0 * (MP.h1 + MP.h2);
		double num5 = Env.RadiusEffective / 1000.0 * MP.range * MP.h1;
		double num6 = 0.05;
		double num7 = 0.1;
		int num8 = 1;
		while ((num8 < 10) & (Math.Abs(num7) > num6))
		{
			num8++;
			double num9 = Math.Pow(num2, 3.0) + num3 * Math.Pow(num2, 2.0) + num4 * num2 + num5;
			double num10 = 3.0 * Math.Pow(num2, 2.0) + 2.0 * num3 * num2 + num4;
			num7 = num9 / num10;
			num2 -= num7;
			if (num2 < 0.0 || num2 > MP.range)
			{
				num2 = MP.range / 2.0;
			}
		}
		double num11 = MP.range - num2;
		double num12 = MP.h1 - num2 * num2 / (2.0 * Env.RadiusEffective / 1000.0);
		double num13 = MP.h2 - num11 * num11 / (2.0 * Env.RadiusEffective / 1000.0);
		double d = num * num12 * num13 / MP.range + 3.14159265358979;
		double gamma = ((!(MP.h2 >= MP.h1)) ? (num2 / Env.RadiusEffective) : (num11 / Env.RadiusEffective));
		double patd = default(double);
		double dr = default(double);
		opffac(gamma, MP.Frequency, OP.opmaxd, MP.h1, MP.h2, num2, num11, ref patd, ref dr, ref Env, ref AP);
		double num14 = patd * patd + dr * dr + 2.0 * dr * patd * Math.Cos(d);
		if (num14 < 1E-07)
		{
			num14 = 1E-07;
		}
		return -10.0 * Math.Log10(num14);
	}

	public static void opffac(double gamma, double Frequency, double range, double h1, double h2, double r1, double r2, ref double patd, ref double dr, ref Weather.WeatherProfile Env, ref TAntennaParams AP)
	{
		double num = 1.0;
		double num2 = (h2 - h1) * 0.001;
		double num3 = h1 - r1 * r1 * 1000.0 / (2.0 * Env.RadiusEffective);
		double num4 = num3 / r1;
		double num5 = 0.001 * num4;
		if (num5 > 0.05236)
		{
			num5 = Math.Atan(0.001 * num3 / r1);
		}
		double num6 = num2 / range - range / (2.0 * Env.RadiusEffective);
		num = antpat(num6, num6, ref AP);
		patd = num;
		num = antpat(0.0 - (gamma + num5), num6, ref AP);
		double num7 = SeaRoughness(Env.SeaState, Frequency, num5);
		double num8 = 1.0 / Math.Sqrt(1.0 + 2.0 * r1 * r2 / Env.RadiusEffective / (range * Math.Sin(num5)));
		dr = num * num7 * num8 * 1.0;
	}

	public static void InitAntennaParams(TAntennaType AntennaType, double BeamWidth, double Elevation, ref TAntennaParams AP)
	{
		AP.AntennaType = AntennaType;
		AP.antbwr = 0.0174532925199433 * BeamWidth;
		AP.antelr = 0.0174532925199433 * Elevation;
		AP.elmaxr = 1.047;
		switch (AntennaType)
		{
		case TAntennaType.at_Gaussian:
		{
			double num2 = Math.Sin(AP.antbwr / 2.0);
			double num3 = num2 * num2;
			AP.antfac = (0.0 - Math.Log(2.0)) / (2.0 * num3);
			AP.patrfac = Math.Sin(AP.antelr);
			double num = Math.Sqrt(10.11779 * num3);
			AP.elmaxr = AP.antelr + Math.Atan(num / Math.Sqrt(1.0 - num * num));
			break;
		}
		case TAntennaType.at_Coseq_Sq:
			AP.elmaxr = AP.antelr + 0.78525;
			AP.antfac = Math.Sin(AP.antbwr);
			break;
		case TAntennaType.at_Sin_x_x:
		case TAntennaType.at_Height_Finder_Generic:
		{
			AP.antfac = 1.39157 / Math.Sin(AP.antbwr / 2.0);
			double num = 3.14159265358979 / AP.antfac;
			AP.patrfac = 0.0 - Math.Atan(num / Math.Sqrt(1.0 - num * num));
			if (AntennaType == TAntennaType.at_Sin_x_x)
			{
				AP.elmaxr = AP.antelr - AP.patrfac;
			}
			break;
		}
		}
	}

	internal static double antpat(double angle, double alpha, ref TAntennaParams AP)
	{
		double num = 1.0;
		double num2 = ((AP.AntennaType != TAntennaType.at_Height_Finder_Generic || !(alpha > AP.antelr)) ? AP.antelr : alpha);
		double num3 = angle - num2;
		if (AP.AntennaType == TAntennaType.at_Coseq_Sq)
		{
			if (num3 > AP.antbwr)
			{
				num = Math.Sin(AP.antbwr) / Math.Sin(Math.Abs(num3));
			}
			else if (num3 < 0.0)
			{
				num = 1.0 + num3 / AP.antbwr;
				if (num < 0.03)
				{
					num = 0.03;
				}
			}
		}
		else if (AP.AntennaType == TAntennaType.at_Gaussian)
		{
			double num4 = Math.Sin(angle) - AP.patrfac;
			num = Math.Exp(AP.antfac * num4 * num4);
			if (num < 0.03)
			{
				num = 0.03;
			}
		}
		else if (num3 != 0.0)
		{
			if (!(num3 <= AP.patrfac) && 0.0 - num3 > AP.patrfac)
			{
				double num5 = AP.antfac * Math.Sin(num3);
				num = Math.Sin(num5) / num5;
				if (num > 1.0)
				{
					num = 1.0;
				}
				if (num < 0.03)
				{
					num = 0.03;
				}
			}
			else
			{
				num = 0.03;
			}
		}
		return num;
	}

	public static void skipzone(ref TMetricParams MP, ref TOpticalParams OP, ref double rsbd, ref double rsbdloss, ref double SBD_Gain_dB, double fsterm, TEvapDuctParams EDP, Weather.WeatherProfile Env)
	{
		double radiusEffective = Env.RadiusEffective;
		double ED_Gain_dB = default(double);
		hgain(MP.h2, ref SBD_Gain_dB, ref ED_Gain_dB, MP.Frequency, EDP, ref Env);
		rsbd = 0.0;
		if (MP.h2 <= Env.SurfaceDuctHeight)
		{
			double num = 0.9 * Env.SurfaceDuctHeight;
			double num2 = 0.001 / radiusEffective;
			double num3 = num * num2 * 2.0;
			double num4 = num * num2 / (0.1 * Env.SurfaceDuctHeight);
			double num5 = Math.Sqrt(num3);
			double num6 = num5 / num4;
			double num8;
			if (MP.h1 <= num)
			{
				double num7 = Math.Sqrt(num3 - (num - MP.h1) * 2.0 * num2);
				num8 = num6 + (num5 - num7) / num2;
			}
			else
			{
				num8 = Math.Sqrt(num4 * 2.0 * (Env.SurfaceDuctHeight - MP.h1)) / num4;
			}
			double num10;
			if (MP.h2 <= num)
			{
				double num9 = Math.Sqrt(num3 - (num - MP.h2) * 2.0 * num2);
				num10 = num6 + (num5 - num9) / num2;
			}
			else
			{
				num10 = Math.Sqrt(num4 * 2.0 * (Env.SurfaceDuctHeight - MP.h2)) / num4;
			}
			rsbd = (num8 + num10) / 1000.0;
			if (rsbd < OP.r1min)
			{
				rsbd = OP.r1min;
			}
			rsbdloss = fsterm + 20.0 * Math.Log10(rsbd) - SBD_Gain_dB;
		}
	}

	internal static double SeaRoughnessFromWind(double WindSpeed_ms, double Frequency, double GrazingAngle)
	{
		double num = 0.0051 * WindSpeed_ms * WindSpeed_ms;
		double num2 = Frequency / 1000000.0 / 299792458.0 * num * 2.0 * 3.14159265358979;
		double result = 1.0;
		if (num != 0.0)
		{
			double num3 = num2 * 2.0 * Math.Sin(GrazingAngle * 0.0174532925199433);
			double num4 = 0.5 * num3 * num3;
			double num5 = 3.2 * num4;
			double num6 = num5 - 2.0 + Math.Sqrt(num5 * num5 - 7.0 * num4 + 9.0);
			if (num6 > 0.0)
			{
				result = 1.0 / Math.Sqrt(num6);
			}
		}
		return result;
	}

	internal static double SeaRoughness(int SeaState, double Frequency, double GrazingAngle)
	{
		double num = 0.0;
		switch (SeaState)
		{
		case 0:
			num = 0.0;
			break;
		case 1:
			num = 0.05;
			break;
		case 2:
			num = 0.3;
			break;
		case 3:
			num = 0.875;
			break;
		case 4:
			num = 1.875;
			break;
		case 5:
			num = 3.25;
			break;
		case 6:
			num = 5.0;
			break;
		case 7:
			num = 7.5;
			break;
		case 8:
			num = 11.5;
			break;
		case 9:
			num = 15.0;
			break;
		}
		double num2 = Frequency / 1000000.0 / 299792458.0 * num * 2.0 * 3.14159265358979;
		double result = 1.0;
		if (num != 0.0)
		{
			double x = num2 * 2.0 * Math.Sin(GrazingAngle * 0.0174532925199433);
			double num3 = 0.5 * Math.Pow(x, 2.0);
			double num4 = 3.2 * num3 - 2.0 + Math.Sqrt(Math.Pow(3.2 * num3, 2.0) - 7.0 * num3 + 9.0);
			if (num4 > 0.0)
			{
				result = 1.0 / Math.Sqrt(num4);
			}
		}
		return result;
	}

	internal static double BasicElevatedDuctOneWayLoss(double Frequency, double BeamWidth, double DuctPathLength, double LayerThickness, double MLayerGradient)
	{
		double num = 0.03;
		double num2 = BeamWidth * 0.0174532925199433 / 1000.0;
		double d = Frequency / 1000000000.0;
		double value = LayerThickness * MLayerGradient / 1000.0;
		double value2 = Math.Sqrt(2.0 * Math.Abs(value));
		double num3 = ((!(2.0 * Math.Abs(value2) <= num2)) ? 0.0 : (-10.0 * Math.Log10(2.0 * Math.Abs(value2) / BeamWidth)));
		return 92.45 + 20.0 * Math.Log10(d) + 10.0 * Math.Log10(DuctPathLength) + num * DuctPathLength + num3;
	}

	internal static double PRF_From_MaximumRangeNM(double MIR)
	{
		return 299792458.0 / (2.0 * MIR * 1852.0);
	}

	internal static double MRound(double N, double D)
	{
		if (Math.Abs(MathFunctions.Sign(D) - MathFunctions.Sign(N)) == 2)
		{
			throw new Exception("MRound cannot accept arguments of different signs");
		}
		double num = Math.Abs(D);
		double num2 = Math.Abs(N);
		if (num2 - num * Conversion.Fix(num2 / num) >= num / 2.0)
		{
			return (double)MathFunctions.Sign(N) * num * (Conversion.Fix(num2 / num) + 1.0);
		}
		return (double)MathFunctions.Sign(N) * num * Conversion.Fix(num2 / num);
	}

	internal static double SurfaceClutterCellArea(double DistanceToCell, double VertBeamWidth, double HorzBeamWidth, double PulseWidth, double GrazingAngle)
	{
		double num = DistanceToCell * 1852.0;
		double val = 3.14159265358979 * num * num * Math.Tan(HorzBeamWidth * 0.0174532925199433 / 2.0) * Math.Tan(VertBeamWidth * 0.0174532925199433 / 2.0) / Math.Sin(GrazingAngle * 0.0174532925199433);
		double val2 = num * HorzBeamWidth * 0.0174532925199433 * 299792458.0 * PulseWidth * 1E-06 / (2.0 * Math.Cos(GrazingAngle * 0.0174532925199433));
		return Math.Min(val, val2);
	}

	internal static double SurfaceClutterCellArea_dB(double DistanceToCell, double VertBeamWidth, double HorzBeamWidth, double PulseWidth, double GrazingAngle)
	{
		double num = DistanceToCell * 1852.0;
		double val = 3.14159265358979 * num * num * Math.Tan(HorzBeamWidth * 0.0174532925199433 / 2.0) * Math.Tan(VertBeamWidth * 0.0174532925199433 / 2.0) / Math.Sin(GrazingAngle * 0.0174532925199433);
		double val2 = num * HorzBeamWidth * 0.0174532925199433 * 299792458.0 * PulseWidth * 1E-06 / (2.0 * Math.Cos(GrazingAngle * 0.0174532925199433));
		return Math.Log10(Math.Min(val, val2)) * 10.0;
	}

	internal static double specific_atten_rain(double Frequency, double RainFallRate, double ElevationAngle, double Polarization)
	{
		double num = Frequency / 1000000000.0;
		double[] array = new double[26]
		{
			1.0, 2.0, 4.0, 6.0, 7.0, 8.0, 10.0, 12.0, 15.0, 20.0,
			25.0, 30.0, 35.0, 40.0, 45.0, 50.0, 60.0, 70.0, 80.0, 90.0,
			100.0, 120.0, 150.0, 200.0, 300.0, 400.0
		};
		double[] array2 = new double[26]
		{
			3.87E-05, 0.000154, 0.00065, 0.00175, 0.00301, 0.00454, 0.0101, 0.0188, 0.0367, 0.0751,
			0.124, 0.187, 0.263, 0.35, 0.442, 0.536, 0.707, 0.851, 0.975, 1.06,
			1.12, 1.18, 1.31, 1.45, 1.36, 1.32
		};
		double[] array3 = new double[26]
		{
			3.52E-05, 0.000138, 0.000591, 0.00155, 0.00265, 0.00395, 0.00887, 0.0168, 0.0335, 0.0691,
			0.113, 0.167, 0.233, 0.31, 0.393, 0.479, 0.642, 0.784, 0.906, 0.999,
			1.06, 1.13, 1.27, 1.42, 1.35, 1.31
		};
		double[] array4 = new double[26]
		{
			0.912, 0.963, 1.121, 1.308, 1.332, 1.327, 1.276, 1.217, 1.154, 1.099,
			1.061, 1.021, 0.979, 0.939, 0.903, 0.873, 0.826, 0.793, 0.769, 0.753,
			0.743, 0.731, 0.71, 0.689, 0.688, 0.683
		};
		double[] array5 = new double[26]
		{
			0.88, 0.923, 1.075, 1.265, 1.312, 1.31, 1.264, 1.2, 1.128, 1.065,
			1.03, 1.0, 0.963, 0.929, 0.897, 0.868, 0.824, 0.793, 0.769, 0.754,
			0.744, 0.732, 0.711, 0.69, 0.689, 0.684
		};
		int num2 = 0;
		double num4 = default(double);
		double num5 = default(double);
		double num6 = default(double);
		double num7 = default(double);
		do
		{
			if (!(num < array[num2 + 1]))
			{
				num2++;
				continue;
			}
			double num3 = Math.Log10(num / array[num2]) / Math.Log10(array[num2 + 1] / array[num2]);
			num4 = array2[num2] * Math.Pow(array2[num2 + 1] / array2[num2], num3);
			num5 = array3[num2] * Math.Pow(array3[num2 + 1] / array3[num2], num3);
			num6 = array4[num2] + (array4[num2 + 1] - array4[num2]) * num3;
			num7 = array5[num2] + (array5[num2 + 1] - array5[num2]) * num3;
			break;
		}
		while (num2 <= 23);
		double num8 = Math.Cos(0.0174532925199433 * ElevationAngle);
		double num9 = num8 * num8 * Math.Cos(0.0349065850398866 * Polarization);
		double num10 = (num4 + num5 + (num4 - num5) * num9) / 2.0;
		double y = (num4 * num6 + num5 * num7 + (num4 * num6 - num5 * num7) * num9) / (2.0 * num10);
		return num10 * Math.Pow(RainFallRate, y);
	}

	internal static bool SimpleRadarEquation(ref TRadar Radar, double Target_RCSm2, double DistanceToTarget)
	{
		if (DistanceToTarget <= 0.0)
		{
			return false;
		}
		if (Radar.PulseWidth == 0.0)
		{
			return false;
		}
		int result;
		if (Radar.HorzBeamWidth != 0.0)
		{
			if (Radar.VertBeamWidth != 0.0)
			{
				if (Radar.Frequency == 0.0)
				{
					return false;
				}
				double num = 10.0 * Math.Log10(12.56637061435916 / (2.0 * Math.Sin(Radar.HorzBeamWidth * 0.0174532925199433 / 2.0) * Radar.VertBeamWidth * 0.0174532925199433));
				double num2 = 1.0 / (Radar.PulseWidth * 1E-06);
				double num3 = Math.Pow(10.0, num / 10.0);
				double num4 = 299792458.0 / Radar.Frequency;
				double num5 = Radar.AntennaTemp + Radar.ReceiverTemp;
				double num6 = 1.380650424E-23 * num5 * num2;
				double num7 = 1.0 * num6;
				double num8 = Math.Pow(10.0, Radar.ProcessingGain / 10.0);
				double num9 = Math.Pow(10.0, FreeSpaceOneWayLoss(DistanceToTarget * 1852.0 / 1000.0, Radar.Frequency) / 10.0);
				double num10 = Radar.PowerOutputW * (num3 * num3) * Target_RCSm2 * num8 * 4.0 * 3.14159265358979 / (num9 * num9 * num4 * num4);
				if (num7 <= num10)
				{
					return true;
				}
				return false;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	internal static double FreeSpaceDetectionRangeNM(ref TRadar Radar, double Target_RCSm2)
	{
		double num = 0.01;
		double num2 = 1000.0;
		if (SimpleRadarEquation(ref Radar, Target_RCSm2, num))
		{
			while (SimpleRadarEquation(ref Radar, Target_RCSm2, num2))
			{
				num = num2;
				num2 = num * 2.0;
			}
			double num3;
			while (true)
			{
				num3 = (num2 - num) / 2.0 + num;
				if (num2 - num < 0.01)
				{
					break;
				}
				if (!SimpleRadarEquation(ref Radar, Target_RCSm2, num3))
				{
					num2 = num3;
				}
				else
				{
					num = num3;
				}
			}
			return num3;
		}
		return 0.0;
	}

	internal static float GetDesiredXSectionValue(XSection DesiredXS, ActiveUnit theUnit, float TargetAspect)
	{
		if (!(TargetAspect >= 315f) && TargetAspect > 45f)
		{
			if ((TargetAspect >= 45f && TargetAspect <= 135f) || (TargetAspect >= 225f && TargetAspect <= 315f))
			{
				return DesiredXS.get_Side(theUnit);
			}
			if (TargetAspect >= 135f && TargetAspect <= 225f)
			{
				return DesiredXS.get_Rear(theUnit);
			}
			float result = default(float);
			return result;
		}
		return DesiredXS.get_Front(theUnit);
	}

	internal static float CalculateBistaticRCS_db(ActiveUnit theUnit, XSection._SignatureType DesiredSignatureType, Module_Unit.Unit theEmitter, Module_Unit.Unit theReceiver)
	{
		XSection xSection = Sensor.smethod_0(theUnit, DesiredSignatureType);
		if (xSection == null)
		{
			xSection = Sensor.smethod_0(theUnit, DesiredSignatureType);
		}
		if (xSection == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		}
		if (xSection.isDBInvisible(theUnit))
		{
			return 0f;
		}
		float num = Module_Unit.BearingToUnit_Relative(theUnit, theEmitter, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		float num2 = Module_Unit.BearingToUnit_Relative(theUnit, theReceiver, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		float desiredXSectionValue = GetDesiredXSectionValue(xSection, theUnit, num);
		float desiredXSectionValue2 = GetDesiredXSectionValue(xSection, theUnit, num2);
		if (MathFunctions.AngularDifference(num, num2) <= 10f)
		{
			return desiredXSectionValue;
		}
		float incomingAzimuth = Module_Unit.BearingToUnit_True(theUnit, theEmitter);
		float newBearing = Module_Unit.BearingToUnit_True(theUnit, theReceiver);
		float num3 = Math.Abs(MathFunctions.AngularDifference(Math2.SpecularReflectionAzimuth(theUnit.CurrentHeading, incomingAzimuth), newBearing));
		float num4 = ((num3 < 5f) ? (desiredXSectionValue2 + 20f) : ((!(num3 < 10f)) ? desiredXSectionValue2 : (desiredXSectionValue2 + 10f)));
		float num5 = Math.Abs(MathFunctions.AngularDifference(Math2.SpecularReflectionAzimuth(Math2.NormalizeBearing(theUnit.CurrentHeading - 120f), incomingAzimuth), newBearing));
		num4 = ((num5 < 5f) ? Math.Max(num4, desiredXSectionValue2 + 10f) : ((!(num5 < 10f)) ? Math.Max(desiredXSectionValue2, num4) : Math.Max(num4, desiredXSectionValue2 + 5f)));
		float num6 = Math.Abs(MathFunctions.AngularDifference(Math2.SpecularReflectionAzimuth(Math2.NormalizeBearing(theUnit.CurrentHeading + 120f), incomingAzimuth), newBearing));
		return (!(num6 >= 5f)) ? Math.Max(num4, desiredXSectionValue2 + 10f) : ((!(num6 < 10f)) ? Math.Max(desiredXSectionValue2, num4) : Math.Max(num4, desiredXSectionValue2 + 5f));
	}

	public static float ModifiedSignature_MobileUnits_db(Sensor theSensor, float OriginalTargetSignature_db, ActiveUnit theUnit)
	{
		TTarget tTarget = new TTarget();
		tTarget.RCS = OriginalTargetSignature_db;
		double num = tTarget.RCS_m2;
		if (Module_ActiveUnit.IsAimpointFacility(theUnit))
		{
			int num2 = default(int);
			foreach (Mount mount in theUnit.Mounts)
			{
				if (mount.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					num2++;
				}
			}
			if (num2 == 0)
			{
				return 0f;
			}
			num *= Math.Sqrt(num2);
		}
		float num3 = theUnit.CurrentSpeed / (float)theUnit.Kinematics.GetMaximumSpeed(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Flank, ValidateAndFixAltitude: false);
		float num4 = ((num3 == 0f) ? 1f : ((num3 < 0.2f) ? 30f : ((num3 < 0.4f) ? 60f : ((num3 < 0.6f) ? 120f : ((!(num3 < 0.8f)) ? 500f : 250f)))));
		Sensor.RadioElectronicFrequency[] searchFreqs = theSensor.SearchFreqs;
		float num5 = default(float);
		foreach (Sensor.RadioElectronicFrequency obj in searchFreqs)
		{
			if (obj.Band == Sensor.FrequencyBand.J_Band)
			{
				num5 = 0.1f;
			}
			if (obj.Band == Sensor.FrequencyBand.K_Band)
			{
				num5 = 0.2f;
			}
			if (obj.Band == Sensor.FrequencyBand.L_Band)
			{
				num5 = 0.3f;
			}
			if (obj.Band == Sensor.FrequencyBand.M_Band)
			{
				num5 = 0.4f;
			}
		}
		num4 = Math.Max(1f, num4 * (1f + num5));
		if (theSensor.Codes.SyntheticApertureRadar && theUnit.CurrentSpeed == 0f)
		{
			num4 = Math.Max(num4, 500f);
		}
		num *= (double)num4;
		tTarget.RCS_m2 = num;
		return (float)tTarget.RCS;
	}

	internal static Geodesic_Vincenty.TCoord MultiBearing(int NumBearings, ref Geodesic_Vincenty.TCoord[] BearingPoints, ref double[] Bearings)
	{
		return default(Geodesic_Vincenty.TCoord);
	}

	public static void Main()
	{
		TRadar tRadar = new TRadar();
		TJammer[] array = new TJammer[2]
		{
			new TJammer(),
			null
		};
		TTarget tTarget = new TTarget();
		Weather.WeatherProfile weatherProfile = new Weather.WeatherProfile();
		tRadar.Altitude = 10f;
		tRadar.VertBeamWidth = 16.0;
		tRadar.AntennaGain = 28.5;
		tRadar.PowerOutputW = 280000.0;
		tRadar.ProcessingGain = 0.0;
		tRadar.SystemNoiseLevel = 5.5;
		tRadar.PulseWidth = 125.0;
		tRadar.Frequency = 5600000000.0;
		tRadar.PRF = 800.0;
		tRadar.ElevationAngle = 0.0;
		array[0].Altitude = 500.0;
		array[0].Gain = 3.0;
		array[0].Bandwidth = 2000000.0;
		array[0].OutputW = 100.0;
		tTarget.Altitude = 10f;
		tTarget.RCS = 20.1;
		weatherProfile.FractionUnderRain = 0.5f;
		weatherProfile.GroundReflectionCoeff = 1.0;
		weatherProfile.SurfaceDuctHeight = 0.0;
		weatherProfile.EvaporationDuctHeight = 0.0;
		new StreamWriter("TESTFILE");
	}
}
