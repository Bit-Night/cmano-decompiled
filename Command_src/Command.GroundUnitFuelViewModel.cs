using System;
using System.Collections.Generic;
using System.Linq;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class GroundUnitFuelViewModel : PlatFormViewModel
{
	private double double_0;

	private string string_1;

	public double Percentage
	{
		get
		{
			return double_0;
		}
		set
		{
			SetProperty(ref double_0, value, "Percentage");
		}
	}

	public string Text
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "Text");
		}
	}

	[Obsolete("Used for design time only", true)]
	public GroundUnitFuelViewModel()
	{
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void Refresh()
	{
		base.UnitName = theUnit.Name;
		double TotalCurrent = default(double);
		double TotalMax = default(double);
		Percentage = (int)Math.Round(theUnit.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0);
		long num = ((Vehicle)theUnit).get_FuelEndurance(theUnit.ThrottleSetting, (AltBand)null, (float?)(int)Math.Round(theUnit.DesiredSpeed), (float?)0f);
		HashSet<string> hashSet = new HashSet<string>();
		string text = "";
		foreach (FuelRec item in theUnit.Fuel_ReadOnly)
		{
			hashSet.Add(item.FuelType.ToString());
		}
		if (hashSet.Count > 0)
		{
			text = " (" + string.Join(", ", hashSet.ToArray()) + ")";
			if (hashSet.Count > 1)
			{
				text = "\r\n" + text;
			}
		}
		string text2 = Conversions.ToString(Math.Round(TotalCurrent, 0)) + " fuel units remaining";
		if (!string.IsNullOrEmpty(text))
		{
			text2 += text;
		}
		string text3 = ((theUnit.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? "Unit is at full stop" : (Misc.TimeString(num, 0, ReturnNo: false, ReturnZero: true) + ", " + Conversions.ToString(Math.Round((float)num * theUnit.CurrentSpeed / 3600f, 0)) + " nm"));
		Text = text2 + "\r\n" + text3;
	}

	public GroundUnitFuelViewModel(Vehicle theUnit)
	{
		base.theUnit = theUnit;
		Refresh();
	}

	static GroundUnitFuelViewModel()
	{
		Class72.smethod_20();
	}
}
