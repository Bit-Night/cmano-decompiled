using System.Management;
using SmartAssembly.Attributes;

[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class DiskDrive : BaseWin32Entity
{
	public DiskDrive(ManagementBaseObject obj)
		: base(obj)
	{
	}

	static DiskDrive()
	{
		Class72.smethod_20();
	}
}
