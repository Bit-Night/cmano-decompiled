using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace SRTM.Logging.LogProviders;

[ExcludeFromCodeCoverage]
internal static class TraceEventTypeValues
{
	internal static readonly Type Type;

	internal static readonly int Verbose;

	internal static readonly int Information;

	internal static readonly int Warning;

	internal static readonly int Error;

	internal static readonly int Critical;

	static TraceEventTypeValues()
	{
		Class72.smethod_20();
		Assembly assemblyPortable = TypeExtensions.GetAssemblyPortable(typeof(Uri));
		if (!(assemblyPortable == null))
		{
			Type = assemblyPortable.GetType("System.Diagnostics.TraceEventType");
			if (!(Type == null))
			{
				Verbose = (int)Enum.Parse(Type, "Verbose", ignoreCase: false);
				Information = (int)Enum.Parse(Type, "Information", ignoreCase: false);
				Warning = (int)Enum.Parse(Type, "Warning", ignoreCase: false);
				Error = (int)Enum.Parse(Type, "Error", ignoreCase: false);
				Critical = (int)Enum.Parse(Type, "Critical", ignoreCase: false);
			}
		}
	}
}
