namespace CommandNetcode.Merge;

public interface IScenarioMerge
{
	ScenarioMergeOutput MergeScenarioXML(ScenarioMergeInput input);

	string MergeName();
}
