using System;

namespace DotSpatial.Topology;

public interface IVectorD : ICoordinate, ICloneable, IComparable
{
	double Length { get; }

	Vector Add(Vector v);

	Vector Cross(Vector v);

	double Dot(Vector v);

	Vector Multiply(double scalar);

	void Normalize();

	Vector Subtract(Vector v);
}
