using System;
using System.Diagnostics.CodeAnalysis;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal class LoupeLogProvider : LogProviderBase
{
	internal delegate void WriteDelegate(int severity, string logSystem, int skipFrames, Exception exception, bool attributeToException, int writeMode, string detailsXml, string category, string caption, string description, params object[] args);

	[ExcludeFromCodeCoverage]
	internal class LoupeLogger
	{
		private readonly string string_0;

		private readonly WriteDelegate writeDelegate_0;

		private readonly int int_0;

		internal LoupeLogger(string category, WriteDelegate logWriteDelegate)
		{
			string_0 = category;
			writeDelegate_0 = logWriteDelegate;
			int_0 = 1;
		}

		public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception, params object[] formatParameters)
		{
			if (messageFunc == null)
			{
				return true;
			}
			messageFunc = LogMessageFormatter.SimulateStructuredLogging(messageFunc, formatParameters);
			writeDelegate_0(smethod_0(logLevel), "LibLog", int_0, exception, true, 0, null, string_0, null, messageFunc());
			return true;
		}

		private static int smethod_0(LogLevel logLevel_0)
		{
			return logLevel_0 switch
			{
				LogLevel.Trace => TraceEventTypeValues.Verbose, 
				LogLevel.Debug => TraceEventTypeValues.Verbose, 
				LogLevel.Info => TraceEventTypeValues.Information, 
				LogLevel.Warn => TraceEventTypeValues.Warning, 
				LogLevel.Error => TraceEventTypeValues.Error, 
				LogLevel.Fatal => TraceEventTypeValues.Critical, 
				_ => throw new ArgumentOutOfRangeException("logLevel"), 
			};
		}

		static LoupeLogger()
		{
			Class72.smethod_20();
		}
	}

	private static bool bool_0;

	private readonly WriteDelegate NjpyoIqdagD;

	public static bool ProviderIsAvailableOverride
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public LoupeLogProvider()
	{
		if (!IsLoggerAvailable())
		{
			throw new InvalidOperationException("Gibraltar.Agent.Log (Loupe) not found");
		}
		NjpyoIqdagD = smethod_1();
	}

	public override Logger GetLogger(string name)
	{
		return new LoupeLogger(name, NjpyoIqdagD).Log;
	}

	public static bool IsLoggerAvailable()
	{
		if (bool_0)
		{
			return smethod_0() != null;
		}
		return false;
	}

	private static Type smethod_0()
	{
		return Type.GetType("Gibraltar.Agent.Log, Gibraltar.Agent");
	}

	private static WriteDelegate smethod_1()
	{
		Type type = smethod_0();
		Type type2 = Type.GetType("Gibraltar.Agent.LogMessageSeverity, Gibraltar.Agent");
		Type type3 = Type.GetType("Gibraltar.Agent.LogWriteMode, Gibraltar.Agent");
		return (WriteDelegate)TypeExtensions.GetMethodPortable(type, "Write", type2, typeof(string), typeof(int), typeof(Exception), typeof(bool), type3, typeof(string), typeof(string), typeof(string), typeof(string), typeof(object[])).CreateDelegate(typeof(WriteDelegate));
	}

	static LoupeLogProvider()
	{
		Class72.smethod_20();
		bool_0 = true;
	}
}
