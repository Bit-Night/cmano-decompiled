using System;

namespace OpenDis.Core;

[AttributeUsage(AttributeTargets.Field, Inherited = true)]
public sealed class InternetDomainCodeAttribute : Attribute
{
	private string string_0;

	public string InternetDomainCode => string_0;

	public InternetDomainCodeAttribute(string internetDomainCode)
	{
		string_0 = internetDomainCode;
	}

	static InternetDomainCodeAttribute()
	{
		Class72.smethod_20();
	}
}
