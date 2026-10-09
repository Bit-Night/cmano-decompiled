using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class CSVUpdate
{
	private enum Enum4
	{

	}

	private static Enum4 smethod_0(string string_0)
	{
		if (Operators.CompareString(string_0, "DUPLICATE LOADOUT", true) == 0)
		{
			return (Enum4)0;
		}
		return (Enum4)1;
	}

	public static void Run(List<List<string>> updateList)
	{
		foreach (List<string> update in updateList)
		{
			Enum4 @enum = smethod_0(update[0]);
			if (@enum != (Enum4)1)
			{
				smethod_1(@enum, update);
			}
		}
	}

	private static void smethod_1(Enum4 enum4_0, List<string> list_0)
	{
		if (enum4_0 == (Enum4)0)
		{
			int sourceLoadoutID = Conversions.ToInteger(list_0[1]);
			int targetAircraftID = Conversions.ToInteger(list_0[3]);
			DeepCopyAircraftLoadouts.PerformLoadoutDuplication(sourceLoadoutID, targetAircraftID);
		}
	}

	static CSVUpdate()
	{
		Class72.smethod_20();
	}
}
