namespace Command_Core;

public class Aircraft_ExampleMission_DecisionChecklist : Aircraft_DecisionChecklist
{
	private static DecisionItem[] SoyLrpnOaPP;

	static Aircraft_ExampleMission_DecisionChecklist()
	{
		Class72.smethod_20();
		SoyLrpnOaPP = new DecisionItem[6]
		{
			new DecisionItem("Example item 1", exampleNonBlocking),
			new DecisionItem("Example item 2", exampleNonBlocking),
			new DecisionItem("Example item 3", exampleNonBlocking),
			new DecisionItem("Evaluate Group RTB", Aircraft_DecisionChecklist.evaluateGroupRTB),
			new DecisionItem("Evaluate fuel state RTB", Aircraft_DecisionChecklist.smethod_4),
			new DecisionItem("Evaluate weapon state RTB", Aircraft_DecisionChecklist.evaluateWeaponStateRTB)
		};
	}

	public override DecisionItem[] getItems()
	{
		return SoyLrpnOaPP;
	}

	public override string getListName()
	{
		return "Aircraft Example Mission AI";
	}

	protected static Result exampleNonBlocking(Aircraft myAircraft)
	{
		return new Result(null, "non blocking");
	}
}
