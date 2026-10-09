using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.GeometriesGraph;

public abstract class GraphComponent
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private Label label_0;

	public virtual Label Label
	{
		get
		{
			return label_0;
		}
		set
		{
			label_0 = value;
		}
	}

	public virtual bool IsInResult
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public virtual bool IsCovered
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			bool_1 = true;
		}
	}

	public virtual bool IsCoveredSet => bool_1;

	public virtual bool IsVisited
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public abstract Coordinate Coordinate { get; set; }

	public abstract bool IsIsolated { get; }

	protected GraphComponent()
	{
	}

	protected GraphComponent(Label inLabel)
	{
		label_0 = inLabel;
	}

	public abstract void ComputeIm(IntersectionMatrix im);

	public virtual void UpdateIm(IntersectionMatrix im)
	{
		Assert.IsTrue(Label.GeometryCount >= 2, "found partial label");
		ComputeIm(im);
	}

	static GraphComponent()
	{
		Class72.smethod_20();
	}
}
