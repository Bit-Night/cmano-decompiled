using System.Management;
using SmartAssembly.Attributes;

[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class MotherboardDevice : BaseWin32Entity
{
	public MotherboardDevice(ManagementBaseObject obj)
		: base(obj)
	{
	}

	public override string ToString()
	{
		return PrintProperties();
	}

	static MotherboardDevice()
	{
		Class72.smethod_20();
	}
}
