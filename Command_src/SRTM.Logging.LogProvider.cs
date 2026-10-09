using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using SRTM.Logging.LogProviders;

namespace SRTM.Logging;

[ExcludeFromCodeCoverage]
public static class LogProvider
{
	internal delegate bool IsLoggerAvailable();

	internal delegate ILogProvider CreateLogProvider();

	[ExcludeFromCodeCoverage]
	internal class NoOpLogger : ILog
	{
		internal static readonly NoOpLogger Instance;

		public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception, params object[] formatParameters)
		{
			return false;
		}

		static NoOpLogger()
		{
			Class72.smethod_20();
			Instance = new NoOpLogger();
		}
	}

	private static ILogProvider ilogProvider_0;

	private static Action<ILogProvider> action_0;

	private static Lazy<ILogProvider> lazy_0;

	[CompilerGenerated]
	private static bool bool_0;

	internal static readonly List<Tuple<IsLoggerAvailable, CreateLogProvider>> LogProviderResolvers;

	public static bool IsDisabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	internal static Action<ILogProvider> OnCurrentLogProviderSet
	{
		set
		{
			action_0 = value;
			smethod_0();
		}
	}

	internal static ILogProvider CurrentLogProvider => (dynamic)ilogProvider_0;

	static LogProvider()
	{
		Class72.smethod_20();
		lazy_0 = new Lazy<ILogProvider>(() => ForceResolveLogProvider());
		LogProviderResolvers = new List<Tuple<IsLoggerAvailable, CreateLogProvider>>
		{
			new Tuple<IsLoggerAvailable, CreateLogProvider>(SerilogLogProvider.IsLoggerAvailable, () => new SerilogLogProvider()),
			new Tuple<IsLoggerAvailable, CreateLogProvider>(NLogLogProvider.IsLoggerAvailable, () => new NLogLogProvider()),
			new Tuple<IsLoggerAvailable, CreateLogProvider>(Class32.IsLoggerAvailable, () => new Class32()),
			new Tuple<IsLoggerAvailable, CreateLogProvider>(EntLibLogProvider.IsLoggerAvailable, () => new EntLibLogProvider()),
			new Tuple<IsLoggerAvailable, CreateLogProvider>(LoupeLogProvider.IsLoggerAvailable, () => new LoupeLogProvider())
		};
		IsDisabled = false;
	}

	public static void SetCurrentLogProvider(ILogProvider logProvider)
	{
		ilogProvider_0 = logProvider;
		smethod_0();
	}

	internal static ILog For<T>()
	{
		return GetLogger(typeof(T));
	}

	internal static ILog GetCurrentClassLogger()
	{
		return GetLogger(new StackFrame(1, needFileInfo: false).GetMethod().DeclaringType);
	}

	internal static ILog GetLogger(Type type, string fallbackTypeName = "System.Object")
	{
		return GetLogger((!(type != null)) ? fallbackTypeName : type.FullName);
	}

	internal static ILog GetLogger(string name)
	{
		ILogProvider logProvider = CurrentLogProvider ?? ResolveLogProvider();
		if (logProvider != null)
		{
			return new LoggerExecutionWrapper(logProvider.GetLogger(name), () => IsDisabled);
		}
		return NoOpLogger.Instance;
	}

	internal static IDisposable OpenNestedContext(string message)
	{
		ILogProvider logProvider = CurrentLogProvider ?? ResolveLogProvider();
		if (logProvider != null)
		{
			return logProvider.OpenNestedContext(message);
		}
		return new DisposableAction(delegate
		{
		});
	}

	internal static IDisposable OpenMappedContext(string key, object value, bool destructure = false)
	{
		ILogProvider logProvider = CurrentLogProvider ?? ResolveLogProvider();
		if (logProvider == null)
		{
			return new DisposableAction(delegate
			{
			});
		}
		return logProvider.OpenMappedContext(key, value, destructure);
	}

	private static void smethod_0()
	{
		if (action_0 != null)
		{
			action_0((dynamic)ilogProvider_0);
		}
	}

	internal static ILogProvider ResolveLogProvider()
	{
		return lazy_0.Value;
	}

	internal static ILogProvider ForceResolveLogProvider()
	{
		try
		{
			foreach (Tuple<IsLoggerAvailable, CreateLogProvider> logProviderResolver in LogProviderResolvers)
			{
				if (logProviderResolver.Item1())
				{
					return logProviderResolver.Item2();
				}
			}
		}
		catch (Exception arg)
		{
			Console.WriteLine("Exception occurred resolving a log provider. Logging for this assembly {0} is disabled. {1}", TypeExtensions.GetAssemblyPortable(typeof(LogProvider)).FullName, arg);
		}
		return null;
	}
}
