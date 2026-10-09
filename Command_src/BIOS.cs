using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using SmartAssembly.Attributes;

[DoNotObfuscateTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneTypeAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
[DoNotPruneAttribute{BA58BF82-1BB2-E559-A817-CBA201E12DFC}]
internal class BIOS : BaseWin32Entity
{
	[CompilerGenerated]
	private IEnumerable<BiosCharacteristics> ienumerable_0;

	[CompilerGenerated]
	private string string_5;

	public IEnumerable<BiosCharacteristics> Characteristics
	{
		[CompilerGenerated]
		get
		{
			return ienumerable_0;
		}
		[CompilerGenerated]
		private set
		{
			ienumerable_0 = value;
		}
	}

	public string SerialNumber
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		private set
		{
			string_5 = value;
		}
	}

	public BIOS(ManagementBaseObject obj)
		: base(obj)
	{
		ushort[] source = (ushort[])obj["BiosCharacteristics"];
		Characteristics = source.Select((ushort c) => (BiosCharacteristics)c).ToArray();
		SerialNumber = ParseValue<string>(obj, "SerialNumber");
		if (!string.IsNullOrEmpty(SerialNumber))
		{
			SerialNumber = SerialNumber.ToLower();
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(PrintProperties());
		foreach (BiosCharacteristics characteristic in Characteristics)
		{
			string name = Enum.GetName(typeof(BiosCharacteristics), characteristic);
			stringBuilder.AppendLine(name);
		}
		return stringBuilder.ToString();
	}

	static BIOS()
	{
		Class72.smethod_20();
	}
}
