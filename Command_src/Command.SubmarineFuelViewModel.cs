using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class SubmarineFuelViewModel : PlatFormViewModel
{
	private Visibility visibility_0;

	private double double_0;

	private string string_1;

	private FontWeight fontWeight_0;

	private Visibility visibility_1;

	private double double_1;

	private string FrTeIvgRea;

	private FontWeight fontWeight_1;

	private Visibility visibility_2;

	private double double_2;

	private string string_2;

	private FontWeight DbMexvIwv6;

	private string string_3;

	private double double_3;

	public Visibility VisibilityDiesel
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_0;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_0, value, "VisibilityDiesel");
		}
	}

	public double PercentageDiesel
	{
		get
		{
			return double_0;
		}
		set
		{
			SetProperty(ref double_0, value, "PercentageDiesel");
		}
	}

	public string PercentageDieselText
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "PercentageDieselText");
		}
	}

	public FontWeight FontWeightDiesel
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return fontWeight_0;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref fontWeight_0, value, "FontWeightDiesel");
		}
	}

	public Visibility VisibilityBattery
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_1;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_1, value, "VisibilityBattery");
		}
	}

	public double PercentageBattery
	{
		get
		{
			return double_1;
		}
		set
		{
			SetProperty(ref double_1, value, "PercentageBattery");
		}
	}

	public string PercentageBatteryText
	{
		get
		{
			return FrTeIvgRea;
		}
		set
		{
			SetProperty(ref FrTeIvgRea, value, "PercentageBatteryText");
		}
	}

	public FontWeight FontWeightBattery
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return fontWeight_1;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref fontWeight_1, value, "FontWeightBattery");
		}
	}

	public Visibility VisibilityAIP
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return visibility_2;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref visibility_2, value, "VisibilityAIP");
		}
	}

	public double PercentageAIP
	{
		get
		{
			return double_2;
		}
		set
		{
			SetProperty(ref double_2, value, "PercentageAIP");
		}
	}

	public string PercentageAIPText
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "PercentageAIPText");
		}
	}

	public FontWeight FontWeightAIP
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return DbMexvIwv6;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref DbMexvIwv6, value, "FontWeightAIP");
		}
	}

	public string EnduranceText
	{
		get
		{
			return string_3;
		}
		set
		{
			SetProperty(ref string_3, value, "EnduranceText");
		}
	}

	public double Percentage
	{
		get
		{
			return double_3;
		}
		set
		{
			SetProperty(ref double_3, value, "Percentage");
		}
	}

	[Obsolete("Used for design time only", true)]
	public SubmarineFuelViewModel()
	{
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void Refresh()
	{
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		base.UnitName = theUnit.Name;
		if (theUnit.Fuel_ReadOnly.Count == 0)
		{
			return;
		}
		Submarine submarine = (Submarine)theUnit;
		if (!submarine.IsNuke)
		{
			VisibilityDiesel = (Visibility)1;
			FuelRec fuelRec = theUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.DieselFuel).ElementAtOrDefault(0);
			if (fuelRec != null)
			{
				PercentageDiesel = (int)Math.Round(fuelRec.PercentFull * 100f);
				PercentageDieselText = string.Format("{0:0.0}", fuelRec.CurrentQuantity, 0) + " fuel units remaining";
				VisibilityDiesel = (Visibility)0;
			}
			VisibilityBattery = (Visibility)0;
			FuelRec fuelRec2 = theUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
			if (fuelRec2 != null)
			{
				PercentageBattery = (int)Math.Round(fuelRec2.PercentFull * 100f);
				PercentageBatteryText = string.Format("{0:0.0}", fuelRec2.CurrentQuantity, 0) + " fuel units remaining";
			}
			if (submarine.IsAIP)
			{
				VisibilityAIP = (Visibility)0;
				FuelRec fuelRec3 = theUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.AirIndepedent).ElementAtOrDefault(0);
				PercentageAIP = (int)Math.Round(fuelRec3.PercentFull * 100f);
				PercentageAIPText = string.Format("{0:0.0}", fuelRec3.CurrentQuantity, 0) + " fuel units remaining";
			}
			else
			{
				VisibilityAIP = (Visibility)2;
			}
			FontWeightDiesel = FontWeights.Normal;
			FontWeightAIP = FontWeights.Normal;
			FontWeightBattery = FontWeights.Normal;
			switch (submarine.AI.SelectFuelTypeToConsume(submarine.PrimaryEngine))
			{
			case FuelRec._FuelType.AirIndepedent:
				FontWeightAIP = FontWeights.Bold;
				Percentage = PercentageAIP;
				break;
			case FuelRec._FuelType.Battery:
				FontWeightBattery = FontWeights.Bold;
				Percentage = PercentageBattery;
				break;
			case FuelRec._FuelType.DieselFuel:
				FontWeightDiesel = FontWeights.Bold;
				Percentage = PercentageDiesel;
				break;
			}
			long num = submarine.get_FuelEndurance(theUnit.ThrottleSetting, (AltBand)null, (float?)(int)Math.Round(theUnit.DesiredSpeed), (float?)theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), submarine.PrimaryEngine, submarine.PrimaryEngineNo);
			string text = ((theUnit.ThrottleSetting != ActiveUnit.Throttle.FullStop) ? (Misc.TimeString(num, 0, ReturnNo: false, ReturnZero: true) + ", " + string.Format("{0:0.0}", (float)num * theUnit.CurrentSpeed / 3600f, 0) + " nm") : "Unit is at full stop");
			EnduranceText = "Endurance: " + text;
		}
		else
		{
			VisibilityDiesel = (Visibility)2;
			VisibilityBattery = (Visibility)2;
			VisibilityAIP = (Visibility)2;
		}
	}

	public SubmarineFuelViewModel(Submarine theUnit)
	{
		base.theUnit = theUnit;
		Refresh();
	}

	static SubmarineFuelViewModel()
	{
		Class72.smethod_20();
	}
}
