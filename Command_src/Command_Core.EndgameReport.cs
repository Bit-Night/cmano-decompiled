using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Command_Core;

public class EndgameReport
{
	private Module_Unit.Unit unit_0;

	public bool AnyMessageReportedAsHit;

	public List<string> Messages;

	public List<string> Summaries;

	public Scenario WeaponScenario;

	public Dictionary<string, List<string>> HitMessages;

	public bool HasReported;

	public EndgameReport(Module_Unit.Unit weaponOrUnit)
	{
		PartialReset();
		unit_0 = weaponOrUnit;
	}

	public void PartialReset()
	{
		AnyMessageReportedAsHit = false;
		Messages = new List<string>();
		Summaries = new List<string>();
		HitMessages = new Dictionary<string, List<string>>();
		HasReported = false;
	}

	public void AddEndGameMessage(bool hit, string message)
	{
		if (hit)
		{
			AnyMessageReportedAsHit = true;
		}
		if (!Messages.Contains(message))
		{
			Messages.Add(message);
		}
	}

	public void ReportEndgameAfterReattackTriggered(Scenario scen)
	{
		AttemptEndgameReport(scen);
		PartialReset();
	}

	public void AttemptEndgameReport(Scenario scen)
	{
		if (!HasReported)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = (AnyMessageReportedAsHit ? " HIT" : " MISS");
			bool flag = true;
			foreach (Explosion generatedParentExplosion in unit_0.GeneratedParentExplosions)
			{
				int num;
				if (!generatedParentExplosion.isWaitingSubExplosionEvaluation())
				{
					if (!generatedParentExplosion.isWaitingSubExplosionCleanUp())
					{
						continue;
					}
					num = 0;
				}
				else
				{
					num = 0;
				}
				flag = (byte)num != 0;
				break;
			}
			if (flag && Messages.Count > 0)
			{
				int num2 = Messages.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					stringBuilder.Append(Messages[i]).Append((Messages.Count - 1 == i) ? "." : ", ");
				}
				HasReported = true;
				scen.AddMessage(unit_0.Name + text + ": " + stringBuilder.ToString(), unit_0.Name + string.Format("'s Endgame Report {0}", AnyMessageReportedAsHit ? "HIT" : "MISS"), LoggedMessage.MessageType.WeaponEndgame, 3, unit_0.ObjectID);
			}
		}
		else if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	static EndgameReport()
	{
		Class72.smethod_20();
	}
}
