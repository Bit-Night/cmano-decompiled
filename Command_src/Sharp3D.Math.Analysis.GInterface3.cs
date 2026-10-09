using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public interface GInterface3
{
	double Differentiate(MathFunctions.UnaryFunction<float> f, float x);
}
