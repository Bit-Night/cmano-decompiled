using System.Collections.Generic;

namespace Command_Core;

internal class AreaValidatedObjects
{
	public string Name;

	public Side Side;

	public List<ReferencePoint> Area;

	public bool ValidationResult;

	public string validationResultMessage;

	public AreaValidatedObjects()
	{
	}

	public AreaValidatedObjects(string name, Side side, List<ReferencePoint> area, bool validationResult, string validationResultMessage)
	{
		Name = name;
		Side = side;
		Area = area;
		ValidationResult = validationResult;
		this.validationResultMessage = validationResultMessage;
	}

	static AreaValidatedObjects()
	{
		Class72.smethod_20();
	}
}
