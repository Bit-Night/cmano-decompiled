namespace DotSpatial.Topology.GeometriesGraph;

public class Position
{
	public static PositionType Opposite(PositionType position)
	{
		return position switch
		{
			PositionType.Left => PositionType.Right, 
			PositionType.Right => PositionType.Left, 
			_ => position, 
		};
	}

	static Position()
	{
		Class72.smethod_20();
	}
}
