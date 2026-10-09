namespace DotSpatial.Topology;

public interface IMatrix4 : IMatrixD, IMatrix
{
	IMatrix4 RotateZ(double degrees);

	IMatrix4 RotateX(double degrees);

	IMatrix4 RotateY(double degrees);

	IMatrix4 Translate(double x, double y, double z);
}
