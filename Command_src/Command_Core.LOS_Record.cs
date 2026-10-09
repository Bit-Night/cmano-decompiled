namespace Command_Core;

public sealed class LOS_Record
{
	public string TargetID;

	public bool bool_0;

	public LOS_Record(Module_Unit.Unit theTarget, bool LOS_Exists)
	{
		TargetID = theTarget.ObjectID;
		bool_0 = LOS_Exists;
	}

	static LOS_Record()
	{
		Class72.smethod_20();
	}
}
