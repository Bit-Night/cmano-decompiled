using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SRTM.Logging;

[ExcludeFromCodeCoverage]
internal class LoggerExecutionWrapper : ILog
{
	private interface Interface2
	{
		bool Log(Logger logger, LogLevel logLevel, Func<string> messageFunc, Exception exception, object[] formatParameters);
	}

	private class Class31 : Interface2
	{
		bool Interface2.Log(Logger logger, LogLevel logLevel, Func<string> messageFunc, Exception exception, object[] formatParameters)
		{
			return logger(logLevel, messageFunc, exception, formatParameters);
		}

		static Class31()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>c_0;

		public static Func<bool> func_0;

		public static Func<string> func_1;

		static <>c()
		{
			Class72.smethod_20();
			<>c_0 = new <>c();
		}

		internal bool method_0()
		{
			return false;
		}

		internal string method_1()
		{
			return "Failed to generate log message";
		}
	}

	private readonly Logger gjyyoBwyKlJ;

	private readonly Interface2 interface2_0;

	private readonly Func<bool> func_0;

	internal const string FailedToGenerateLogMessage = "Failed to generate log message";

	private Func<string> func_1;

	internal Logger WrappedLogger => gjyyoBwyKlJ;

	internal LoggerExecutionWrapper(Logger logger, Func<bool> getIsDisabled = null)
	{
		gjyyoBwyKlJ = logger;
		interface2_0 = new Class31();
		func_0 = getIsDisabled ?? ((Func<bool>)(() => false));
	}

	public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
	{
		if (func_0())
		{
			return false;
		}
		if (messageFunc == null)
		{
			return gjyyoBwyKlJ(logLevel, null, null);
		}
		Func<string> func = func_1;
		if (func == null || !func.Equals(messageFunc))
		{
			func = null;
			Type declaringType = messageFunc.Method.DeclaringType;
			if (declaringType == typeof(LogExtensions) || (declaringType != null && declaringType.DeclaringType == typeof(LogExtensions)))
			{
				func = messageFunc;
			}
		}
		if (func == null)
		{
			Func<string> messageFunc2 = delegate
			{
				try
				{
					return messageFunc();
				}
				catch (Exception exception2)
				{
					gjyyoBwyKlJ(LogLevel.Error, <>c.<>c_0.method_1, exception2);
				}
				return (string)null;
			};
			return interface2_0.Log(gjyyoBwyKlJ, logLevel, messageFunc2, exception, formatParameters);
		}
		func_1 = func;
		return gjyyoBwyKlJ(logLevel, LogExtensions.WrapLogSafeInternal(this, messageFunc), exception, formatParameters);
	}

	static LoggerExecutionWrapper()
	{
		Class72.smethod_20();
	}
}
