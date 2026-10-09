namespace Magic.Samples.DisplaySettings;

internal enum DisplayChangeResult
{
	BadDualView = -6,
	BadParam,
	BadFlags,
	NotUpdated,
	BadMode,
	Failed,
	Successful,
	Restart
}
