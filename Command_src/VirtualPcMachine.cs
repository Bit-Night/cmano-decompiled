using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class VirtualPcMachine : BaseVirtualEnvironment
{
	public override string Name => "Microsoft Virtual PC";

	public override bool ContainsProcess(IEnumerable<string> services)
	{
		if (services.Contains("vpcmap") && services.Contains("vmsrvc"))
		{
			return true;
		}
		return services.Contains("vmusrvc");
	}

	static VirtualPcMachine()
	{
		Class72.smethod_20();
	}
}
