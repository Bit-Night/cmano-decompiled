namespace DotSpatial.Topology;

public interface IMatrixD : IMatrix
{
	double[,] Values { get; set; }

	IMatrixD Multiply(double inScalar);

	IMatrixD Multiply(IMatrixD matrix);
}
