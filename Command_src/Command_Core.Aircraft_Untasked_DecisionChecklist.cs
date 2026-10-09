namespace Command_Core;

public class Aircraft_Untasked_DecisionChecklist : Aircraft_DecisionChecklist
{
	private static DecisionItem[] decisionItem_1;

	static Aircraft_Untasked_DecisionChecklist()
	{
		Class72.smethod_20();
		decisionItem_1 = new DecisionItem[3]
		{
			new DecisionItem("Evaluate Group RTB", Aircraft_DecisionChecklist.evaluateGroupRTB),
			new DecisionItem("Evaluate fuel state RTB", Aircraft_DecisionChecklist.smethod_4),
			new DecisionItem("Evaluate weapon state RTB", Aircraft_DecisionChecklist.evaluateWeaponStateRTB)
		};
	}

	public override DecisionItem[] getItems()
	{
		return decisionItem_1;
	}

	public override string getListName()
	{
		return "Aircraft Untasked AI";
	}
}
