using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class VirtualBoxMachine : BaseVirtualEnvironment
{
	public override string Name => "VirtualBox";

	public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
	{
		return disks.Any((DiskDrive d) => d.Model.Contains("vbox"));
	}

	public override bool ContainsProcess(IEnumerable<string> services)
	{
		return services.Contains("vboxservice");
	}

	static VirtualBoxMachine()
	{
		Class72.smethod_20();
	}
}
