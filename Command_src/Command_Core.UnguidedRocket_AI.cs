using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class UnguidedRocket_AI : Weapon_AI
{
	public UnguidedRocket_AI(Weapon theUnit)
		: base(theUnit)
	{
	}

	public override void ManouverTowardsTarget(float elapsedTime)
	{
		if (PrimaryTarget == null)
		{
			return;
		}
		try
		{
			float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
			if (315f > relativeBearing && relativeBearing > 45f && myUnit.CurrentSpeed > PrimaryTarget.CurrentSpeed)
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				return;
			}
			Weapon.WeaponGuidanceType guidance = ((Weapon)myUnit).Guidance;
			if (guidance == Weapon.WeaponGuidanceType.BeamRiding)
			{
				Manouver_PurePursuit(elapsedTime, 0f, 0f);
				return;
			}
			float? estimatedAverageSpeed = myUnit.CurrentSpeed;
			bool AllowAfterburner = false;
			Manouver_InterceptCourse(elapsedTime, estimatedAverageSpeed, ref AllowAfterburner);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 1002343214523463564", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static UnguidedRocket_AI()
	{
		Class72.smethod_20();
	}
}
