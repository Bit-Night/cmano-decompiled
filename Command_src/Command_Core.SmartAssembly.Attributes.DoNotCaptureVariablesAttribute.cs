using System;

namespace Command_Core.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
public sealed class DoNotCaptureVariablesAttribute : Attribute
{
	static DoNotCaptureVariablesAttribute()
	{
		Class72.smethod_20();
	}
}
