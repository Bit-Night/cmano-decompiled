using System.Collections.Generic;

namespace Command.SlitherinePBEM3.Models;

internal class InstanceModel
{
	public int ChallengeID;

	public int InstanceID;

	public string Tournament;

	public int ParentProductID;

	public int SidesNum;

	public int Type;

	public string Title;

	public int StepNum;

	public bool IsPaired;

	public int RequredProductID;

	public string string_0;

	public int Status;

	public string CreatedDateTime;

	public string StartDateTime;

	public string FinishDateTime;

	public string LastPlayDateTime;

	public List<PlayerModel> Players;

	static InstanceModel()
	{
		Class72.smethod_20();
	}
}
