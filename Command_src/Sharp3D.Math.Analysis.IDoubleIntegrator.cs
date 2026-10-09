using Sharp3D.Math.Core;

namespace Sharp3D.Math.Analysis;

public interface IDoubleIntegrator
{
	double Integrate(MathFunctions.UnaryFunction<double> f, double a, double b);
}
