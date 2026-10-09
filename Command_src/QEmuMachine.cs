using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class QEmuMachine : BaseVirtualEnvironment
{
	public override string Name => "QEMU";

	public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
	{
		return disks.Any((DiskDrive d) => d.Name.IndexOf("qemu") >= 0);
	}

	static QEmuMachine()
	{
		Class72.smethod_20();
	}
}
