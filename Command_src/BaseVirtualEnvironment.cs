using System.Collections.Generic;
using SmartAssembly.Attributes;

[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal abstract class BaseVirtualEnvironment : Interface1
{
	public abstract string Name { get; }

	public virtual bool ContainsDevice(IEnumerable<PnPEntity> devices)
	{
		return false;
	}

	public virtual bool ContainsDisk(IEnumerable<DiskDrive> disks)
	{
		return false;
	}

	public virtual bool ContainsProcess(IEnumerable<string> processes)
	{
		return false;
	}

	public virtual bool ContainsService(IEnumerable<WindowsService> services)
	{
		return false;
	}

	public virtual bool IsVirtual(BIOS bios)
	{
		return false;
	}

	public virtual bool IsVirtual(ComputerSystem computer)
	{
		return false;
	}

	public virtual bool Assert(ComputerSystem computer, BIOS bios, IEnumerable<DiskDrive> disks, IEnumerable<PnPEntity> devices, IEnumerable<string> processes, IEnumerable<WindowsService> services)
	{
		bool num = IsVirtual(computer);
		bool flag = IsVirtual(bios);
		bool flag2 = ContainsDisk(disks);
		bool flag3 = ContainsDevice(devices);
		bool flag4 = ContainsProcess(processes);
		bool flag5 = ContainsService(services);
		return num || flag || flag2 || flag3 || flag4 || flag5;
	}

	static BaseVirtualEnvironment()
	{
		Class72.smethod_20();
	}
}
