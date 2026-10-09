using System;
using System.Diagnostics.CodeAnalysis;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal class DisposableAction : IDisposable
{
	private readonly Action action_0;

	public DisposableAction(Action onDispose = null)
	{
		action_0 = onDispose;
	}

	public void Dispose()
	{
		if (action_0 != null)
		{
			action_0();
		}
	}

	static DisposableAction()
	{
		Class72.smethod_20();
	}
}
