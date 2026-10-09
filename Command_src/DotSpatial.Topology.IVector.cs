namespace DotSpatial.Topology;

public interface IVector
{
	double Length { get; set; }

	double Length2D { get; set; }

	double Phi { get; set; }

	double Theta { get; set; }

	IVector TransformCoordinate(IMatrix4 transformMatrix);

	IMatrixD ToMatrix();

	double Norm2();

	IPoint ToPoint();

	Coordinate ToCoordinate();

	ILineSegment ToLineSegment();

	void Normalize();

	IVector Cross(IVector v);

	double Dot(IVector v);

	bool Intersects(IVector v);

	bool Equals(IVector v);

	IVector Subtract(IVector v);

	IVector Add(IVector v);

	IVector Multiply(double scalar);

	IVector RotateX(double degrees);

	IVector RotateY(double degrees);

	IVector RotateZ(double degrees);
}
