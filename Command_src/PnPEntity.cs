using System.Management;
using SmartAssembly.Attributes;

[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class PnPEntity : BaseWin32Entity
{
	public PnPEntity(ManagementBaseObject obj)
		: base(obj)
	{
	}

	static PnPEntity()
	{
		Class72.smethod_20();
	}
}
