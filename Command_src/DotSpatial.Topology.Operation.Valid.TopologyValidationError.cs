namespace DotSpatial.Topology.Operation.Valid;

public class TopologyValidationError
{
	private static readonly string[] string_0;

	private readonly TopologyValidationErrorType topologyValidationErrorType_0;

	private readonly Coordinate coordinate_0;

	public virtual Coordinate Coordinate => coordinate_0;

	public virtual TopologyValidationErrorType ErrorType => topologyValidationErrorType_0;

	public virtual string Message => string_0[(int)topologyValidationErrorType_0];

	public TopologyValidationError(TopologyValidationErrorType errorType, Coordinate pt)
	{
		topologyValidationErrorType_0 = errorType;
		if (pt != null)
		{
			coordinate_0 = (Coordinate)pt.Clone();
		}
	}

	public TopologyValidationError(TopologyValidationErrorType errorType)
		: this(errorType, null)
	{
	}

	public override string ToString()
	{
		return Message + " at or near point " + (object)coordinate_0;
	}

	static TopologyValidationError()
	{
		Class72.smethod_20();
		string_0 = new string[11]
		{
			"Topology Validation Error", "Repeated Point", "Hole lies outside shell", "Holes are nested", "Interior is disconnected", "Self-intersection", "Ring Self-intersection", "Nested shells", "Duplicate Rings", "Too few points in geometry component",
			"Invalid Coordinate"
		};
	}
}
