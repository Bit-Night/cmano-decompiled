using System;

namespace Command.SmartAssembly.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
public sealed class ObfuscateNamespaceToAttribute : Attribute
{
	public ObfuscateNamespaceToAttribute(string newName)
	{
	}

	static ObfuscateNamespaceToAttribute()
	{
		Class72.smethod_20();
	}
}
