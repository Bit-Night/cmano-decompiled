using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public interface IDoubleDifferentiator
{
	double Differentiate(MathFunctions.UnaryFunction<double> f, double x);
}
