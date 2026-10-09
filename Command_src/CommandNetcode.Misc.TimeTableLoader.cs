using System.Collections.Generic;
using System.IO;
using System.Linq;
using SmartAssembly.Attributes;

namespace CommandNetcode.Misc;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public static class TimeTableLoader
{
	public static List<TimeTableItem> LoadTimeTable(string path)
	{
		List<TimeTableItem> list = new List<TimeTableItem>();
		foreach (string item in File.ReadAllLines(path).Skip(2))
		{
			string[] array = item.Split(new char[1] { ',' });
			list.Add(new TimeTableItem
			{
				Type = array[0],
				Warfare = array[1],
				CodeName = array[2],
				DeltaT = int.Parse(array[3]),
				ReactSpeed = int.Parse(array[4]),
				Remarks = array[5]
			});
		}
		return list;
	}

	static TimeTableLoader()
	{
		Class72.smethod_20();
	}
}
