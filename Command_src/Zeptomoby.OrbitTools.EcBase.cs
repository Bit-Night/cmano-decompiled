using System.Runtime.CompilerServices;

namespace Zeptomoby.OrbitTools;

public abstract class EcBase
{
	[CompilerGenerated]
	private Vector vector_0;

	[CompilerGenerated]
	private Vector vector_1;

	public Vector Position
	{
		[CompilerGenerated]
		get
		{
			return vector_0;
		}
		[CompilerGenerated]
		protected set
		{
			vector_0 = value;
		}
	}

	public Vector Velocity
	{
		[CompilerGenerated]
		get
		{
			return vector_1;
		}
		[CompilerGenerated]
		protected set
		{
			vector_1 = value;
		}
	}

	protected EcBase()
	{
	}

	protected EcBase(Vector pos, Vector vel)
	{
		Position = new Vector(pos);
		Velocity = new Vector(vel);
	}

	protected double Distance(EcBase p2)
	{
		return Position.Distance(p2.Position);
	}

	public void ScalePosVector(double factor)
	{
		Position.Scale(factor);
	}

	public void ScaleVelVector(double factor)
	{
		Velocity.Scale(factor);
	}

	public override string ToString()
	{
		return $"km:({Position.X:F0}, {Position.Y:F0}, {Position.Z:F0}) km/s:({Velocity.X:F1}, {Velocity.Y:F1}, {Velocity.Z:F1})";
	}

	static EcBase()
	{
		Class72.smethod_20();
	}
}
