using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class HyperVMachine : BaseVirtualEnvironment
{
	public override string Name => "Microsoft Hyper-V";

	public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
	{
		return disks.Any((DiskDrive d) => d.Caption.Contains("virtual"));
	}

	public override bool IsVirtual(ComputerSystem computer)
	{
		if (!computer.Manufacturer.Contains("microsoft"))
		{
			return false;
		}
		return computer.Model.Contains("virtual");
	}

	static HyperVMachine()
	{
		Class72.smethod_20();
	}
}
