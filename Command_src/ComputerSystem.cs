using System.Management;
using System.Runtime.CompilerServices;
using SmartAssembly.Attributes;

[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class ComputerSystem : BaseWin32Entity
{
	[CompilerGenerated]
	private string string_5;

	public string OEMStringArray
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public ComputerSystem(ManagementBaseObject obj)
		: base(obj)
	{
		object obj2 = obj["OEMStringArray"];
		if (obj2 != null)
		{
			OEMStringArray = ToJSON(obj2).ToLower();
		}
	}

	public override string ToString()
	{
		return PrintProperties();
	}

	static ComputerSystem()
	{
		Class72.smethod_20();
	}
}
