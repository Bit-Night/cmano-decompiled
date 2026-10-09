using System.Collections.Generic;

namespace Command.SlitherinePBEM3.Models;

internal class ChallengeModel
{
	public int ChallengeID;

	public int ParentProductID;

	public int PlayersNum;

	public int SidesNum;

	public int Type;

	public int Title;

	public bool IsPrivate;

	public bool IsPaired;

	public int RequiredProductID;

	public string string_0;

	public int Status;

	public string CreatedDateTime;

	public string StartDateTime;

	public string FinishDateTime;

	public List<ChallengePlayerModel> Players;

	public int StepMaxTime;

	public bool IsQuick;

	public bool IsRanked;

	public int int_0;

	public string string_1;

	static ChallengeModel()
	{
		Class72.smethod_20();
	}
}
