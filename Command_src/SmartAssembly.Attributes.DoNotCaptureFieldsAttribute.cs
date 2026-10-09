using System;

namespace SmartAssembly.Attributes;

[DoNotObfuscate]
[DoNotPrune]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public sealed class DoNotCaptureFieldsAttribute : Attribute
{
	static DoNotCaptureFieldsAttribute()
	{
		Class72.smethod_20();
	}
}
