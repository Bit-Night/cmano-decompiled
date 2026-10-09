using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Module_Weapon
{
	internal static float TerminalVelocity(this Weapon myWeapon)
	{
		double num = (double)(float)myWeapon.BurnoutWeight() * 9.81;
		float num2 = myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		short num3 = myWeapon.WeatherAtMyLocation.ActualTempAtAltitude_CurrentScenarioTime(myWeapon.ParentScen, myWeapon.get_Latitude((GlobalVariables.BooleanObject)null), myWeapon.get_Longitude((GlobalVariables.BooleanObject)null), 0f);
		Weather.TAtmosphere tAtmosphere = Weather.Standard_Atmosphere_AtThisAltitude(Weather.TAtmosphereType.atm_ITU_R_Ref_Std, num2 / 1000f, num3);
		double num4 = tAtmosphere.Pressure * 100.0 / (287.058 * tAtmosphere.Temperature) + tAtmosphere.Rho / 1000.0;
		double num5 = Math.PI * Math.Pow((double)myWeapon.Diameter * 0.5, 2.0);
		double num6 = myWeapon.BodyDragCoefficient(num2, myWeapon.CurrentSpeed);
		return (float)(Math.Sqrt(2.0 * num / (num4 * num6 * num5)) * 1.94384);
	}

	static Module_Weapon()
	{
		Class72.smethod_20();
	}
}
