using System;
using System.Diagnostics.CodeAnalysis;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal abstract class LogProviderBase : ILogProvider
{
	protected delegate IDisposable OpenNdc(string message);

	protected delegate IDisposable OpenMdc(string key, object value, bool destructure);

	private readonly Lazy<OpenNdc> lazy_0;

	private readonly Lazy<OpenMdc> lazy_1;

	private static readonly IDisposable idisposable_0;

	protected LogProviderBase()
	{
		lazy_0 = new Lazy<OpenNdc>(GetOpenNdcMethod);
		lazy_1 = new Lazy<OpenMdc>(GetOpenMdcMethod);
	}

	public abstract Logger GetLogger(string name);

	public IDisposable OpenNestedContext(string message)
	{
		return lazy_0.Value(message);
	}

	public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
	{
		return lazy_1.Value(key, value, destructure);
	}

	protected virtual OpenNdc GetOpenNdcMethod()
	{
		return (string _) => idisposable_0;
	}

	protected virtual OpenMdc GetOpenMdcMethod()
	{
		return (string _, object __, bool ___) => idisposable_0;
	}

	static LogProviderBase()
	{
		Class72.smethod_20();
		idisposable_0 = new DisposableAction();
	}
}
