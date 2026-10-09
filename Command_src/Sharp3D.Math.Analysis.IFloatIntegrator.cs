using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public interface IFloatIntegrator
{
	float Integrate(MathFunctions.UnaryFunction<float> f, float a, float b);
}
