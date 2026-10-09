using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SRTM.Logging;

[ExcludeFromCodeCoverage]
internal static class LogExtensions
{
	[Serializable]
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>c_0;

		public static Func<string> func_0;

		static <>c()
		{
			Class72.smethod_20();
			<>c_0 = new <>c();
		}

		internal string method_0()
		{
			return "Failed to generate log message";
		}
	}

	public static bool IsDebugEnabled(this ILog logger)
	{
		smethod_0(logger);
		return logger.Log(LogLevel.Debug, null, null);
	}

	public static bool IsErrorEnabled(this ILog logger)
	{
		smethod_0(logger);
		return logger.Log(LogLevel.Error, null, null);
	}

	public static bool IsFatalEnabled(this ILog logger)
	{
		smethod_0(logger);
		return logger.Log(LogLevel.Fatal, null, null);
	}

	public static bool IsInfoEnabled(this ILog logger)
	{
		smethod_0(logger);
		return logger.Log(LogLevel.Info, null, null);
	}

	public static bool IsTraceEnabled(this ILog logger)
	{
		smethod_0(logger);
		return logger.Log(LogLevel.Trace, null, null);
	}

	public static bool IsWarnEnabled(this ILog logger)
	{
		smethod_0(logger);
		return logger.Log(LogLevel.Warn, null, null);
	}

	public static void Debug(this ILog logger, Func<string> messageFunc)
	{
		smethod_0(logger);
		logger.Log(LogLevel.Debug, smethod_4(messageFunc), null);
	}

	public static void Debug(this ILog logger, string message)
	{
		if (logger.IsDebugEnabled())
		{
			logger.Log(LogLevel.Debug, message.smethod_2(), null);
		}
	}

	public static void Debug(this ILog logger, string message, params object[] args)
	{
		logger.DebugFormat(message, args);
	}

	public static void Debug(this ILog logger, Exception exception, string message, params object[] args)
	{
		logger.DebugException(message, exception, args);
	}

	public static void DebugFormat(this ILog logger, string message, params object[] args)
	{
		if (logger.IsDebugEnabled())
		{
			logger.smethod_1(LogLevel.Debug, message, args);
		}
	}

	public static void DebugException(this ILog logger, string message, Exception exception)
	{
		if (logger.IsDebugEnabled())
		{
			logger.Log(LogLevel.Debug, message.smethod_2(), exception);
		}
	}

	public static void DebugException(this ILog logger, string message, Exception exception, params object[] formatParams)
	{
		if (logger.IsDebugEnabled())
		{
			logger.Log(LogLevel.Debug, message.smethod_2(), exception, formatParams);
		}
	}

	public static void Error(this ILog logger, Func<string> messageFunc)
	{
		smethod_0(logger);
		logger.Log(LogLevel.Error, smethod_4(messageFunc), null);
	}

	public static void Error(this ILog logger, string message)
	{
		if (logger.IsErrorEnabled())
		{
			logger.Log(LogLevel.Error, message.smethod_2(), null);
		}
	}

	public static void Error(this ILog logger, string message, params object[] args)
	{
		logger.ErrorFormat(message, args);
	}

	public static void Error(this ILog logger, Exception exception, string message, params object[] args)
	{
		logger.ErrorException(message, exception, args);
	}

	public static void ErrorFormat(this ILog logger, string message, params object[] args)
	{
		if (logger.IsErrorEnabled())
		{
			logger.smethod_1(LogLevel.Error, message, args);
		}
	}

	public static void ErrorException(this ILog logger, string message, Exception exception, params object[] formatParams)
	{
		if (logger.IsErrorEnabled())
		{
			logger.Log(LogLevel.Error, message.smethod_2(), exception, formatParams);
		}
	}

	public static void Fatal(this ILog logger, Func<string> messageFunc)
	{
		logger.Log(LogLevel.Fatal, smethod_4(messageFunc), null);
	}

	public static void Fatal(this ILog logger, string message)
	{
		if (logger.IsFatalEnabled())
		{
			logger.Log(LogLevel.Fatal, message.smethod_2(), null);
		}
	}

	public static void Fatal(this ILog logger, string message, params object[] args)
	{
		logger.FatalFormat(message, args);
	}

	public static void Fatal(this ILog logger, Exception exception, string message, params object[] args)
	{
		logger.FatalException(message, exception, args);
	}

	public static void FatalFormat(this ILog logger, string message, params object[] args)
	{
		if (logger.IsFatalEnabled())
		{
			logger.smethod_1(LogLevel.Fatal, message, args);
		}
	}

	public static void FatalException(this ILog logger, string message, Exception exception, params object[] formatParams)
	{
		if (logger.IsFatalEnabled())
		{
			logger.Log(LogLevel.Fatal, message.smethod_2(), exception, formatParams);
		}
	}

	public static void Info(this ILog logger, Func<string> messageFunc)
	{
		smethod_0(logger);
		logger.Log(LogLevel.Info, smethod_4(messageFunc), null);
	}

	public static void Info(this ILog logger, string message)
	{
		if (logger.IsInfoEnabled())
		{
			logger.Log(LogLevel.Info, message.smethod_2(), null);
		}
	}

	public static void Info(this ILog logger, string message, params object[] args)
	{
		logger.InfoFormat(message, args);
	}

	public static void Info(this ILog logger, Exception exception, string message, params object[] args)
	{
		logger.InfoException(message, exception, args);
	}

	public static void InfoFormat(this ILog logger, string message, params object[] args)
	{
		if (logger.IsInfoEnabled())
		{
			logger.smethod_1(LogLevel.Info, message, args);
		}
	}

	public static void InfoException(this ILog logger, string message, Exception exception, params object[] formatParams)
	{
		if (logger.IsInfoEnabled())
		{
			logger.Log(LogLevel.Info, message.smethod_2(), exception, formatParams);
		}
	}

	public static void Trace(this ILog logger, Func<string> messageFunc)
	{
		smethod_0(logger);
		logger.Log(LogLevel.Trace, smethod_4(messageFunc), null);
	}

	public static void Trace(this ILog logger, string message)
	{
		if (logger.IsTraceEnabled())
		{
			logger.Log(LogLevel.Trace, message.smethod_2(), null);
		}
	}

	public static void Trace(this ILog logger, string message, params object[] args)
	{
		logger.TraceFormat(message, args);
	}

	public static void Trace(this ILog logger, Exception exception, string message, params object[] args)
	{
		logger.TraceException(message, exception, args);
	}

	public static void TraceFormat(this ILog logger, string message, params object[] args)
	{
		if (logger.IsTraceEnabled())
		{
			logger.smethod_1(LogLevel.Trace, message, args);
		}
	}

	public static void TraceException(this ILog logger, string message, Exception exception, params object[] formatParams)
	{
		if (logger.IsTraceEnabled())
		{
			logger.Log(LogLevel.Trace, message.smethod_2(), exception, formatParams);
		}
	}

	public static void Warn(this ILog logger, Func<string> messageFunc)
	{
		smethod_0(logger);
		logger.Log(LogLevel.Warn, smethod_4(messageFunc), null);
	}

	public static void Warn(this ILog logger, string message)
	{
		if (logger.IsWarnEnabled())
		{
			logger.Log(LogLevel.Warn, message.smethod_2(), null);
		}
	}

	public static void Warn(this ILog logger, string message, params object[] args)
	{
		logger.WarnFormat(message, args);
	}

	public static void Warn(this ILog logger, Exception exception, string message, params object[] args)
	{
		logger.WarnException(message, exception, args);
	}

	public static void WarnFormat(this ILog logger, string message, params object[] args)
	{
		if (logger.IsWarnEnabled())
		{
			logger.smethod_1(LogLevel.Warn, message, args);
		}
	}

	public static void WarnException(this ILog logger, string message, Exception exception, params object[] formatParams)
	{
		if (logger.IsWarnEnabled())
		{
			logger.Log(LogLevel.Warn, message.smethod_2(), exception, formatParams);
		}
	}

	private static void smethod_0(object object_0)
	{
		if (object_0 == null)
		{
			throw new ArgumentNullException("logger");
		}
	}

	private static void smethod_1(this ILog ilog_0, LogLevel logLevel_0, object object_0, params object[] args)
	{
		ilog_0.Log(logLevel_0, ((string)object_0).smethod_2(), null, args);
	}

	private static Func<T> smethod_2<T>(this T gparam_0) where T : class
	{
		return gparam_0.smethod_3;
	}

	private static T smethod_3<T>(this T gparam_0)
	{
		return gparam_0;
	}

	internal static Func<string> WrapLogSafeInternal(LoggerExecutionWrapper logger, Func<string> messageFunc)
	{
		return delegate
		{
			try
			{
				return messageFunc();
			}
			catch (Exception exception)
			{
				logger.WrappedLogger(LogLevel.Error, <>c.<>c_0.method_0, exception);
			}
			return (string)null;
		};
	}

	private static Func<string> smethod_4(Func<string> func_0)
	{
		return () => func_0();
	}

	static LogExtensions()
	{
		Class72.smethod_20();
	}
}
