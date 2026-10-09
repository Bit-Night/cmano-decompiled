using System;

namespace Command_Core;

public abstract class DecisionChecklist
{
	public struct Result
	{
		public bool istantiatedThroughNonDefaultConstructor;

		public string decisionItemName;

		public bool isListEvaluationResult;

		public ActiveUnit._ActiveUnitStatus? finalStatus;

		public string reason;

		public Result(ActiveUnit._ActiveUnitStatus? finalStatus, string reason, bool isListEvaluationResult = false)
		{
			this = default(Result);
			istantiatedThroughNonDefaultConstructor = true;
			this.finalStatus = finalStatus;
			this.reason = reason;
			this.isListEvaluationResult = isListEvaluationResult;
		}

		public bool isBlocking()
		{
			return finalStatus.HasValue;
		}

		public void setDecisionItemName(string decisionItemName)
		{
			this.decisionItemName = decisionItemName;
		}

		public override bool Equals(object obj)
		{
			if ((object)obj.GetType() == typeof(Result))
			{
				Result result = ((obj == null) ? default(Result) : ((Result)obj));
				return string.Equals(decisionItemName, result.decisionItemName) && string.Equals(reason, result.reason) && Nullable.Equals(finalStatus, result.finalStatus);
			}
			return false;
		}

		static Result()
		{
			Class72.smethod_20();
		}
	}

	public abstract string getListName();

	public abstract void addToDebugItemsResults(Result itemResult, DecisionChecklist rootList);

	static DecisionChecklist()
	{
		Class72.smethod_20();
	}
}
