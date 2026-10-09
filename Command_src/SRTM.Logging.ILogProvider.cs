using System;

namespace SRTM.Logging;

public interface ILogProvider
{
	Logger GetLogger(string name);

	IDisposable OpenNestedContext(string message);

	IDisposable OpenMappedContext(string key, object value, bool destructure = false);
}
