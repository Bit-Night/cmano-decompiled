using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sharp3D.Math.Core;

[Serializable]
public sealed class Polynomial : IComparable, ICloneable
{
	private double[] double_0;

	public int Order
	{
		get
		{
			return double_0.Length - 1;
		}
		set
		{
			if (value != double_0.Length - 1)
			{
				double[] array = new double[value + 1];
				double_0.CopyTo(array, 0);
				double_0 = array;
			}
		}
	}

	public double this[int index]
	{
		get
		{
			return double_0[index];
		}
		set
		{
			double_0[index] = value;
		}
	}

	public Polynomial(int order)
	{
		double_0 = new double[order + 1];
	}

	public Polynomial(double[] coefficients)
	{
		double_0 = new double[coefficients.Length];
		for (int i = 0; i < coefficients.Length; i++)
		{
			double_0[i] = coefficients[i];
		}
	}

	public Polynomial(List<double> coefficients)
	{
		double_0 = new double[coefficients.Count];
		for (int i = 0; i < coefficients.Count; i++)
		{
			double_0[i] = coefficients[i];
		}
	}

	public Polynomial(Polynomial polynomial)
	{
		double_0 = new double[polynomial.double_0.Length];
		for (int i = 0; i < double_0.Length; i++)
		{
			double_0[i] = polynomial.double_0[i];
		}
	}

	object ICloneable.Clone()
	{
		return new Polynomial(this);
	}

	public Polynomial Clone()
	{
		return new Polynomial(this);
	}

	int IComparable.CompareTo(object obj)
	{
		if (obj != null)
		{
			Polynomial polynomial = obj as Polynomial;
			if (polynomial == null)
			{
				throw new ArgumentException("Type mismatch: polynomial expected.", "obj");
			}
			return CompareTo(polynomial);
		}
		throw new ArgumentException("Parameter cannot be null.", "obj");
	}

	public int CompareTo(Polynomial p)
	{
		int num = double_0.Length - 1;
		int num2 = p.double_0.Length - 1;
		while (true)
		{
			if (num != num2)
			{
				if (num > num2)
				{
					if (double_0[num--] != 0.0)
					{
						return 1;
					}
				}
				else if (p.double_0[num2--] != 0.0)
				{
					break;
				}
				continue;
			}
			while (true)
			{
				if (num >= 0)
				{
					if (!(double_0[num] <= p.double_0[num]))
					{
						break;
					}
					if (double_0[num] >= p.double_0[num])
					{
						num--;
						continue;
					}
					return -1;
				}
				return 0;
			}
			return 1;
		}
		return -1;
	}

	public Polynomial GetInverse()
	{
		int order = Order;
		Polynomial polynomial = new Polynomial(order);
		for (int i = 0; i < double_0.Length; i++)
		{
			polynomial.double_0[i] = double_0[order - i];
		}
		return polynomial;
	}

	public Polynomial GetDerivative()
	{
		throw new NotImplementedException();
	}

	public void Compress(double tolerance)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Add(Polynomial left, Polynomial right)
	{
		Polynomial polynomial;
		Polynomial polynomial2;
		if (left.Order >= right.Order)
		{
			polynomial = left;
			polynomial2 = right;
		}
		else
		{
			polynomial = right;
			polynomial2 = left;
		}
		Polynomial polynomial3 = new Polynomial(polynomial);
		for (int i = 0; i < polynomial2.double_0.Length; i++)
		{
			polynomial3.double_0[i] += polynomial2.double_0[i];
		}
		return polynomial3;
	}

	public static Polynomial Add(Polynomial p, double scalar)
	{
		throw new NotImplementedException();
	}

	public static void Add(Polynomial left, Polynomial right, Polynomial result)
	{
		Polynomial polynomial;
		Polynomial polynomial2;
		if (left.Order >= right.Order)
		{
			polynomial = left;
			polynomial2 = right;
		}
		else
		{
			polynomial = right;
			polynomial2 = left;
		}
		result.Order = polynomial.Order;
		for (int i = 0; i < polynomial2.double_0.Length; i++)
		{
			result.double_0[i] = polynomial.double_0[i] + polynomial2.double_0[i];
		}
		for (int j = polynomial2.double_0.Length; j < polynomial.double_0.Length; j++)
		{
			result.double_0[j] = polynomial.double_0[j];
		}
	}

	public static void Add(Polynomial p, double scalar, Polynomial result)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Subtract(Polynomial left, Polynomial right)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Subtract(Polynomial p, double scalar)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Subtract(double scalar, Polynomial p)
	{
		throw new NotImplementedException();
	}

	public static void Subtract(Polynomial left, Polynomial right, Polynomial result)
	{
		Polynomial polynomial;
		Polynomial polynomial2;
		if (left.Order >= right.Order)
		{
			polynomial = left;
			polynomial2 = right;
		}
		else
		{
			polynomial = right;
			polynomial2 = left;
		}
		result.Order = polynomial.Order;
		for (int i = 0; i < polynomial2.double_0.Length; i++)
		{
			result.double_0[i] = polynomial.double_0[i] + polynomial2.double_0[i];
		}
		for (int j = polynomial2.double_0.Length; j < polynomial.double_0.Length; j++)
		{
			result.double_0[j] = polynomial.double_0[j];
		}
	}

	public static void Subtract(Polynomial p, double scalar, Polynomial result)
	{
		throw new NotImplementedException();
	}

	public static void Subtract(double scalar, Polynomial p, Polynomial result)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Multiply(Polynomial left, Polynomial right)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Multiply(Polynomial p, double scalar)
	{
		throw new NotImplementedException();
	}

	public static void Multiply(Polynomial left, Polynomial right, Polynomial result)
	{
		throw new NotImplementedException();
	}

	public static void Multiply(Polynomial p, double scalar, Polynomial result)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Divide(Polynomial p, double scalar)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Divide(double scalar, Polynomial p)
	{
		throw new NotImplementedException();
	}

	public static void Divide(Polynomial p, double scalar, Polynomial result)
	{
		throw new NotImplementedException();
	}

	public static void Divide(double scalar, Polynomial p, Polynomial result)
	{
		throw new NotImplementedException();
	}

	public static Polynomial Negate(Polynomial p)
	{
		throw new NotImplementedException();
	}

	public override bool Equals(object obj)
	{
		Polynomial p = obj as Polynomial;
		if (obj == null)
		{
			return false;
		}
		return CompareTo(p) == 0;
	}

	public override int GetHashCode()
	{
		return double_0.GetHashCode();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < double_0.Length; i++)
		{
			if (double_0[i] != 0.0)
			{
				stringBuilder.Append((double_0[i] < 0.0) ? "-" : "+");
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "{0}", double_0[i]));
				stringBuilder.Append("x");
				if (i > 1)
				{
					stringBuilder.Append("^");
					stringBuilder.Append(i.ToString());
				}
			}
		}
		return stringBuilder.ToString();
	}

	public static bool operator ==(Polynomial left, Polynomial right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Polynomial left, Polynomial right)
	{
		return !left.Equals(right);
	}

	public static bool operator >(Polynomial left, Polynomial right)
	{
		return left.CompareTo(right) == 1;
	}

	public static bool operator <(Polynomial left, Polynomial right)
	{
		return left.CompareTo(right) == -1;
	}

	public static bool operator >=(Polynomial left, Polynomial right)
	{
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(Polynomial left, Polynomial right)
	{
		return left.CompareTo(right) <= 0;
	}

	public static Polynomial operator -(Polynomial polynomial)
	{
		return Negate(polynomial);
	}

	public static Polynomial operator +(Polynomial left, Polynomial right)
	{
		return Add(left, right);
	}

	public static Polynomial operator +(Polynomial polynomial, double scalar)
	{
		return Add(polynomial, scalar);
	}

	public static Polynomial operator +(double scalar, Polynomial polynomial)
	{
		return Add(polynomial, scalar);
	}

	public static Polynomial operator -(Polynomial left, Polynomial right)
	{
		return Subtract(left, right);
	}

	public static Polynomial operator -(Polynomial polynomial, double scalar)
	{
		return Subtract(polynomial, scalar);
	}

	public static Polynomial operator -(double scalar, Polynomial polynomial)
	{
		return Subtract(scalar, polynomial);
	}

	public static Polynomial operator *(Polynomial left, Polynomial right)
	{
		return Multiply(left, right);
	}

	public static Polynomial operator *(Polynomial polynomial, double scalar)
	{
		return Multiply(polynomial, scalar);
	}

	public static Polynomial operator *(double scalar, Polynomial polynomial)
	{
		return Multiply(polynomial, scalar);
	}

	public static Polynomial operator /(Polynomial polynomial, double scalar)
	{
		return Divide(polynomial, scalar);
	}

	public static Polynomial operator /(double scalar, Polynomial polynomial)
	{
		return Divide(scalar, polynomial);
	}

	static Polynomial()
	{
		Class72.smethod_20();
	}
}
