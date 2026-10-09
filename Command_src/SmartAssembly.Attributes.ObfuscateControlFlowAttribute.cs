using System;

namespace SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
public sealed class ObfuscateControlFlowAttribute : Attribute
{
	static ObfuscateControlFlowAttribute()
	{
		Class72.smethod_20();
	}
}
