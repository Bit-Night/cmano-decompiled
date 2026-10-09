using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class ActiveUnit_DecisionChecklist<SubjectType> : DecisionChecklist where SubjectType : ActiveUnit
{
	public class DecisionItem
	{
		public delegate Result SimpleEvaluatorDelegate(SubjectType subject);

		public delegate Result SublistEvaluatorDelegate(SubjectType subject, DecisionChecklist rootList);

		public string name;

		private SimpleEvaluatorDelegate simpleEvaluatorDelegate_0;

		private SublistEvaluatorDelegate sublistEvaluatorDelegate_0;

		internal static object object_0;

		public DecisionItem(string name, SimpleEvaluatorDelegate evaluator)
		{
			this.name = name;
			simpleEvaluatorDelegate_0 = evaluator;
		}

		public DecisionItem(string name, SublistEvaluatorDelegate evaluator)
		{
			this.name = name;
			sublistEvaluatorDelegate_0 = evaluator;
		}

		public Result Evaluate(SubjectType subject, DecisionChecklist rootList)
		{
			if (simpleEvaluatorDelegate_0 != null)
			{
				return simpleEvaluatorDelegate_0(subject);
			}
			return sublistEvaluatorDelegate_0(subject, rootList);
		}

		static DecisionItem()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	private bool bool_0;

	private List<Result> list_0;

	private static object object_0;

	protected ActiveUnit_DecisionChecklist()
	{
		bool_0 = false;
	}

	public abstract DecisionItem[] getItems();

	public Result evaluate(SubjectType Subject, DecisionChecklist rootList)
	{
		return evaluate(getItems(), Subject, rootList);
	}

	public override void addToDebugItemsResults(Result itemResult, DecisionChecklist rootList)
	{
		if (rootList == null)
		{
			if (list_0 == null)
			{
				list_0 = new List<Result>();
			}
			list_0.Add(itemResult);
		}
		else
		{
			rootList.addToDebugItemsResults(itemResult, null);
		}
	}

	protected Result evaluate(DecisionItem[] decisionChecklistItems, SubjectType subject, DecisionChecklist rootList)
	{
		bool flag = subject.AI.ActiveSecondsLeftInDebugModeAI > 0f;
		Result result = new Result(null, "No blocking action required", isListEvaluationResult: true);
		try
		{
			if (rootList == null && flag)
			{
				list_0 = new List<Result>();
			}
			foreach (DecisionItem decisionItem in decisionChecklistItems)
			{
				Result result2 = ((rootList != null) ? decisionItem.Evaluate(subject, rootList) : decisionItem.Evaluate(subject, this));
				if (!result2.istantiatedThroughNonDefaultConstructor && Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (flag && !result2.isListEvaluationResult)
				{
					result2.setDecisionItemName(getListName() + ": " + decisionItem.name);
					addToDebugItemsResults(result2, rootList);
				}
				if (result2.finalStatus.HasValue)
				{
					result = result2;
					if (result2.isBlocking())
					{
						break;
					}
				}
			}
			if (rootList == null && flag && list_0 != null)
			{
				bool flag2 = false;
				if (subject.AI.StatusEvaluationDebugHistory.Count == 0)
				{
					flag2 = true;
				}
				else if (subject.AI.StatusEvaluationDebugHistory.Last().Item2.Count != list_0.Count)
				{
					flag2 = true;
				}
				else
				{
					int num = subject.AI.StatusEvaluationDebugHistory.Last().Item2.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						Result result3 = subject.AI.StatusEvaluationDebugHistory.Last().Item2.ElementAt(j);
						Result result4 = list_0.ElementAt(j);
						if (!result3.Equals(result4))
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					subject.AI.StatusEvaluationDebugHistory.Enqueue((((ActiveUnit)subject/*cast due to .constrained prefix*/).get_UnitSide(SetSideOnly: false).ParentScen.Time, list_0));
					if (subject.AI.StatusEvaluationDebugHistory.Count > 5)
					{
						subject.AI.StatusEvaluationDebugHistory.Dequeue();
					}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			bool_0 = false;
		}
		result.isListEvaluationResult = true;
		return result;
	}

	static ActiveUnit_DecisionChecklist()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
