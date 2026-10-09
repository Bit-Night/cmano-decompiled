using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class VmWarePlayer : VmWareMachine
{
	public override bool IsVirtual(BIOS bios)
	{
		return bios.SerialNumber.Contains("vmware");
	}

	public override bool IsVirtual(ComputerSystem computer)
	{
		if (!computer.Manufacturer.Contains("vmware") && !computer.Model.Contains("vmware"))
		{
			if (computer.OEMStringArray == null)
			{
				return false;
			}
			return computer.OEMStringArray.Contains("virtual");
		}
		return true;
	}

	public override bool ContainsDisk(IEnumerable<DiskDrive> disks)
	{
		return disks.Any((DiskDrive d) => d.Model.Contains("vmware"));
	}

	public override bool ContainsDevice(IEnumerable<PnPEntity> devices)
	{
		if (devices.Any((PnPEntity d) => d.Name.Equals("vmware pointing device")))
		{
			goto IL_00f8;
		}
		int result;
		if (devices.Any((PnPEntity d) => d.Name.Contains("vmware sata")))
		{
			result = 1;
		}
		else if (devices.Any((PnPEntity d) => d.Name.Equals("vmware usb pointing device")))
		{
			result = 1;
		}
		else
		{
			if (devices.Any((PnPEntity d) => d.Name.Equals("vmware vmci bus device")))
			{
				goto IL_00f8;
			}
			if (!devices.Any((PnPEntity d) => d.Name.Equals("vmware virtual s scsi disk device")))
			{
				return devices.Any((PnPEntity d) => d.Name.StartsWith("vmware svga"));
			}
			result = 1;
		}
		goto IL_00f9;
		IL_00f9:
		return (byte)result != 0;
		IL_00f8:
		result = 1;
		goto IL_00f9;
	}

	public override bool ContainsService(IEnumerable<WindowsService> services)
	{
		if (!services.Any((WindowsService s) => s.CommandLine.Contains("vmware") && s.Name.Equals("vmtools")) && !services.Any((WindowsService s) => s.CommandLine.Contains("vmware") && s.Name.Equals("tpvcgateway")))
		{
			return services.Any((WindowsService s) => s.CommandLine.Contains("vmware") && s.Name.Equals("tpautoconnsvc"));
		}
		return true;
	}

	static VmWarePlayer()
	{
		Class72.smethod_20();
	}
}
