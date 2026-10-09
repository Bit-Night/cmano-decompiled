using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class Module_ActiveUnit_Weaponry
{
	internal static string ToEnglishString(this ActiveUnit_Weaponry.DLZResultEnum theDLZResult)
	{
		switch (theDLZResult)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return theDLZResult.ToString();
		case ActiveUnit_Weaponry.DLZResultEnum.None:
			return "Undefined";
		case ActiveUnit_Weaponry.DLZResultEnum.Success:
			return "OK";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_OutOfEnergy:
			return "Out of DLZ range";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_OutsideValidAltitudeEnvelope:
			return "Out of valid intercept altitude envelope";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_CannotPlotIntercept:
			return "Unable to intercept target";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_TargetNotDefined:
			return "Target not defined";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_ExhaustedConsumables:
			return "Out of practical launch range";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_CodeError:
			return "Code error";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_TargetWillImpactBeforeIntercept:
			return "Target will impact before intercept is feasible";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_InsideMinimumRange:
			return "Intercept will occur within weapon's minimum range";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_MAXRangeWRA:
			return "Target outside WRA prescribed range";
		case ActiveUnit_Weaponry.DLZResultEnum.Fail_ScenarioDuration:
			return "Unable to intercept within scenario time scale.";
		}
	}

	static Module_ActiveUnit_Weaponry()
	{
		Class72.smethod_20();
	}
}
