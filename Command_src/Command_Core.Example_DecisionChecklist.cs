using System;

namespace Command_Core;

public class Example_DecisionChecklist : ActiveUnit_DecisionChecklist<ActiveUnit>
{
	private static Aircraft_Untasked_DecisionChecklist ShaLrgaKjcY;

	private static DecisionItem[] mhhLraAslme;

	static Example_DecisionChecklist()
	{
		Class72.smethod_20();
		ShaLrgaKjcY = new Aircraft_Untasked_DecisionChecklist();
		mhhLraAslme = new DecisionItem[3]
		{
			new DecisionItem("Example direct", exampleDelegateDirect),
			new DecisionItem("Example conditional", exampleConditional),
			new DecisionItem("Example sub-list", exampleDelegateSubList)
		};
	}

	public override DecisionItem[] getItems()
	{
		throw new NotImplementedException();
	}

	public override string getListName()
	{
		return "Example decision list";
	}

	protected static Result exampleDelegateDirect(ActiveUnit myUnit)
	{
		return new Result(null, "example 1");
	}

	protected static Result exampleConditional(ActiveUnit myUnit)
	{
		Result result = new Result(null, "example 2");
		return result;
	}

	protected static Result exampleDelegateSubList(ActiveUnit myUnit, DecisionChecklist rootList)
	{
		if (!myUnit.IsAircraft)
		{
			Result result = new Result(null, "no action taken");
			return result;
		}
		return ShaLrgaKjcY.evaluate((Aircraft)myUnit, rootList);
	}
}
