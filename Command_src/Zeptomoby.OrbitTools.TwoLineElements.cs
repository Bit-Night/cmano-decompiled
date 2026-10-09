using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public sealed class TwoLineElements : OrbitalElements
{
	public TwoLineElements(string name, string line1, string line2)
	{
		base.SatelliteName = name;
		base.NoradIdStr = line1.Substring(2, 5);
		base.IntlDesignatorStr = line1.Substring(9, 8).Replace(" ", string.Empty);
		int num = smethod_2(line1.Substring(18, 2));
		double doy = smethod_1(line1.Substring(20, 12));
		base.Epoch = new Julian((num >= 57) ? (num + 1900) : (num + 2000), doy);
		base.MeanMotionDt = smethod_1(((line1[33] == '-') ? "-0" : "0") + line1.Substring(34, 10));
		base.BStar = smethod_1(smethod_0(line1.Substring(53, 8)));
		string text = line1.Substring(64, 4).TrimStart(Array.Empty<char>());
		if (string.IsNullOrEmpty(text))
		{
			text = "0";
		}
		base.SetNumber = smethod_2(text);
		base.Eccentricity = smethod_1("0." + line2.Substring(26, 7));
		base.InclinationDeg = smethod_1(line2.Substring(8, 8));
		base.RAANodeDeg = smethod_1(line2.Substring(17, 8));
		base.ArgPerigeeDeg = smethod_1(line2.Substring(34, 8));
		base.MeanAnomalyDeg = smethod_1(line2.Substring(43, 8));
		base.MeanMotion = smethod_1(line2.Substring(52, 11));
		base.InclinationRad = Globals.ToRadians(base.InclinationDeg);
		base.RAANodeRad = Globals.ToRadians(base.RAANodeDeg);
		base.ArgPerigeeRad = Globals.ToRadians(base.ArgPerigeeDeg);
		base.MeanAnomalyRad = Globals.ToRadians(base.MeanAnomalyDeg);
		string text2 = line2.Substring(63, 5).TrimStart(Array.Empty<char>());
		if (string.IsNullOrEmpty(text2))
		{
			text2 = "0";
		}
		base.RevAtEpoch = smethod_2(text2);
	}

	private static string smethod_0(string string_3)
	{
		string text = string_3.Substring(0, 1);
		string text2 = string_3.Substring(1, 5);
		string text3 = string_3.Substring(6, 2).TrimStart(Array.Empty<char>());
		return double.Parse(text + "0." + text2 + "e" + text3, CultureInfo.InvariantCulture).ToString("F" + (text2.Length + Math.Abs(int.Parse(text3, CultureInfo.InvariantCulture))), CultureInfo.InvariantCulture);
	}

	[CompilerGenerated]
	internal static double smethod_1(string str)
	{
		return double.Parse(str, CultureInfo.InvariantCulture);
	}

	[CompilerGenerated]
	internal static int smethod_2(string str)
	{
		return int.Parse(str, CultureInfo.InvariantCulture);
	}

	static TwoLineElements()
	{
		Class72.smethod_20();
	}
}
