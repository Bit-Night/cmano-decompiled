using System;

namespace DotSpatial.Topology;

public class Vector : Coordinate
{
	public double Length
	{
		get
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}
		set
		{
			double length = Length;
			if (length == 0.0)
			{
				X = value;
				return;
			}
			double num = value / length;
			X *= num;
			Y *= num;
			Z *= num;
		}
	}

	public double Length2D
	{
		get
		{
			return Math.Sqrt(X * X + Y * Y);
		}
		set
		{
			double length2D = Length2D;
			if (length2D == 0.0)
			{
				X = value;
				return;
			}
			double num = value / length2D;
			X *= num;
			Y *= num;
		}
	}

	public double Phi
	{
		get
		{
			double length = Length;
			if (length == 0.0)
			{
				return 0.0;
			}
			return Math.Asin(Z / length);
		}
		set
		{
			double length = Length;
			if (length == 0.0)
			{
				X = Math.Cos(value);
				Z = Math.Sin(value);
			}
			else
			{
				Z = length * Math.Sin(value);
				Length2D = length * Math.Cos(value);
			}
		}
	}

	public double Theta
	{
		get
		{
			if (Length2D == 0.0)
			{
				return 0.0;
			}
			double num = Math.Atan(Y / X);
			if (X < 0.0)
			{
				num = Math.PI - num;
			}
			if (X > 0.0 && Y < 0.0)
			{
				num = Math.PI * 2.0 + num;
			}
			return num;
		}
		set
		{
			double length2D = Length2D;
			if (length2D == 0.0)
			{
				X = Math.Cos(value);
				Y = Math.Sin(value);
			}
			else
			{
				X = length2D * Math.Cos(value);
				Y = length2D * Math.Sin(value);
			}
		}
	}

	public Vector()
	{
	}

	public Vector(Coordinate coord)
	{
		X = coord.X;
		Y = coord.Y;
		Z = coord.Z;
		method_0();
	}

	public Vector(ICoordinate inPoint)
	{
		X = inPoint.X;
		Y = inPoint.Y;
		Z = inPoint.Z;
	}

	public Vector(ILineSegmentBase inLineSegment)
	{
		X = inLineSegment.P1.X - inLineSegment.P0.X;
		Y = inLineSegment.P1.Y - inLineSegment.P0.Y;
		Z = inLineSegment.P1.Z - inLineSegment.P0.Z;
	}

	public Vector(Coordinate startCoord, Coordinate endCoord)
	{
		X = endCoord.X - startCoord.X;
		Y = endCoord.Y - startCoord.Y;
		Z = endCoord.Z - startCoord.Z;
	}

	public Vector(double x1, double y1, double z1, double x2, double y2, double z2)
	{
		X = x2 - x1;
		Y = y2 - y1;
		Z = z2 - z1;
	}

	public Vector(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public Vector(double newMagnitude, Angle theta, Angle phi)
	{
		X = newMagnitude * Angle.Cos(theta) * Angle.Cos(phi);
		Y = newMagnitude * Angle.Sin(theta) * Angle.Cos(phi);
		Z = newMagnitude * Angle.Sin(phi);
	}

	public Vector(double newMagnitude, Angle theta)
	{
		X = newMagnitude * Angle.Cos(theta);
		Y = newMagnitude * Angle.Sin(theta);
		Z = 0.0;
	}

	public Vector(Vector vect)
	{
		X = vect.X;
		Y = vect.Y;
		Z = vect.Z;
	}

	public Vector(IMatrixD mat)
	{
		X = mat.Values[0, 0];
		Y = mat.Values[0, 1];
		Z = mat.Values[0, 2];
	}

	private void method_0()
	{
		if (double.IsNaN(X))
		{
			X = 0.0;
		}
		if (double.IsNaN(Y))
		{
			Y = 0.0;
		}
		if (double.IsNaN(Z))
		{
			Z = 0.0;
		}
	}

	public Vector Add(Vector v)
	{
		return new Vector(X + v.X, Y + v.Y, Z + v.Z);
	}

	public double Norm2()
	{
		return X * X + Y * Y + Z * Z;
	}

	public virtual Vector RotateX(double degrees)
	{
		return new Vector(ToMatrix().Multiply(Matrix4.RotationX(degrees)));
	}

	public virtual Vector RotateY(double degrees)
	{
		return new Vector(ToMatrix().Multiply(Matrix4.RotationY(degrees)));
	}

	public virtual Vector RotateZ(double degrees)
	{
		return new Vector(ToMatrix().Multiply(Matrix4.RotationZ(degrees)));
	}

	public IPoint ToPoint()
	{
		return new Point(X, Y, Z);
	}

	public ILineSegment ToLineSegment()
	{
		return new LineSegment(new Coordinate(0.0, 0.0, 0.0), ToCoordinate());
	}

	public Coordinate ToCoordinate()
	{
		return new Coordinate(X, Y, Z);
	}

	public Vector TransformCoordinate(IMatrix4 transformMatrix)
	{
		double[,] values = ToMatrix().Multiply(transformMatrix).Values;
		return new Vector(values[0, 0], values[0, 1], values[0, 2]);
	}

	public IMatrixD ToMatrix()
	{
		MatrixD matrixD = new MatrixD(1, 4);
		double[,] values = ((IMatrixD)matrixD).Values;
		values[0, 0] = base[0];
		values[0, 1] = base[1];
		values[0, 2] = base[2];
		values[0, 3] = 1.0;
		return matrixD;
	}

	public Vector Subtract(Vector v)
	{
		return new Vector(X - v.X, Y - v.Y, Z - v.Z);
	}

	public void Normalize()
	{
		double num = Math.Sqrt(Math.Pow(X, 2.0) + Math.Pow(Y, 2.0) + Math.Pow(Z, 2.0));
		if (num > 0.0)
		{
			X /= num;
			Y /= num;
			Z /= num;
		}
	}

	public Vector Cross(Vector v)
	{
		return new Vector
		{
			X = Y * v.Z - Z * v.Y,
			Y = Z * v.X - X * v.Z,
			Z = X * v.Y - Y * v.X
		};
	}

	public double Dot(Vector v)
	{
		return X * v.X + Y * v.Y + Z * v.Z;
	}

	public bool Intersects(Vector v)
	{
		if (X == v.X && Y == v.Y && Z == v.Z)
		{
			return true;
		}
		return false;
	}

	public bool Equals(Vector v)
	{
		if (X == v.X && Y == v.Y && Z == v.Z)
		{
			return true;
		}
		return false;
	}

	public override bool Equals(object vect)
	{
		if (!(vect.GetType() == typeof(Vector)))
		{
			return false;
		}
		Vector vector = (Vector)vect;
		if (X == vector.X && Y == vector.Y)
		{
			return Z == vector.Z;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public Vector Multiply(double scalar)
	{
		return new Vector(X * scalar, Y * scalar, Z * scalar);
	}

	public static Vector Add(Vector u, Vector v)
	{
		return new Vector(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
	}

	public static Vector CrossProduct(Vector u, Vector v)
	{
		return new Vector
		{
			X = u.Y * v.Z - u.Z * v.Y,
			Y = u.Z * v.X - u.X * v.Z,
			Z = u.X * v.Y - u.Y * v.X
		};
	}

	public static Vector Divide(Vector u, double scalar)
	{
		if (scalar == 0.0)
		{
			throw new ArgumentException("Divisor cannot be 0.");
		}
		return new Vector(u.X / scalar, u.Y / scalar, u.Z / scalar);
	}

	public static double DotProduct(Vector u, Vector v)
	{
		return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
	}

	public static double Norm2(Vector u)
	{
		return u.X * u.X + u.Y * u.Y + u.Z * u.Z;
	}

	public static Vector Multiply(Vector u, double scalar)
	{
		return new Vector(u.X * scalar, u.Y * scalar, u.Z * scalar);
	}

	public static Vector Subtract(Vector u, Vector v)
	{
		return new Vector(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
	}

	public static Vector operator +(Vector u, Vector v)
	{
		return new Vector(u.X + v.X, u.Y + v.Y, u.Z + v.Z);
	}

	public static bool operator ==(Vector u, Vector v)
	{
		if (u.X == v.X && u.Y == v.Y && u.Z == v.Z)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(Vector u, Vector v)
	{
		if (u.X == v.X && u.Y == v.Y && u.Z == v.Z)
		{
			return false;
		}
		return true;
	}

	public static Vector operator ^(Vector u, Vector v)
	{
		return new Vector
		{
			X = u.Y * v.Z - u.Z * v.Y,
			Y = u.Z * v.X - u.X * v.Z,
			Z = u.X * v.Y - u.Y * v.X
		};
	}

	public static double operator *(Vector u, Vector v)
	{
		return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
	}

	public static Vector operator *(double scalar, Vector v)
	{
		return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
	}

	public static Vector operator *(Vector u, double scalar)
	{
		return new Vector(u.X * scalar, u.Y * scalar, u.Z * scalar);
	}

	public static Vector operator -(Vector u, Vector v)
	{
		return new Vector(u.X - v.X, u.Y - v.Y, u.Z - v.Z);
	}

	static Vector()
	{
		Class72.smethod_20();
	}
}
