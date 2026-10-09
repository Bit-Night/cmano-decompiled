using System;

namespace Command_Core.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
public sealed class DoNotObfuscateControlFlowAttribute : Attribute
{
	static DoNotObfuscateControlFlowAttribute()
	{
		Class72.smethod_20();
	}
}
