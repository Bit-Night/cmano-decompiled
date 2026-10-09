using System;

namespace DotSpatial.Topology;

public class MatrixD : IMatrixD, IMatrix
{
	private int int_0;

	private int int_1;

	private double[,] double_0;

	public int M => int_0;

	public int N => int_1;

	public int NumRows => int_0;

	public int NumColumns => int_1;

	public double[,] Values
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			int_0 = double_0.GetLength(0);
			int_1 = double_0.GetLength(1);
		}
	}

	public MatrixD(int m)
	{
		double_0 = new double[m, m];
		int_0 = m;
		int_1 = m;
	}

	public MatrixD(int m, int n)
	{
		double_0 = new double[m, n];
		int_0 = m;
		int_1 = n;
	}

	public MatrixD(double[,] values)
	{
		double_0 = values;
		int_0 = values.GetLength(0);
		int_1 = values.GetLength(1);
	}

	public IMatrixD Multiply(IMatrixD inMatrix)
	{
		if (inMatrix.NumRows != NumColumns)
		{
			throw new ArgumentException("Matrix multiplication only works if the number of columns of the first matrix is the same as the number of rows of the second matrix");
		}
		int numRows = NumRows;
		int numColumns = inMatrix.NumColumns;
		double[,] array = new double[numRows, numColumns];
		for (int i = 0; i < numRows; i++)
		{
			for (int j = 0; j < numColumns; j++)
			{
				array[i, j] = 0.0;
				for (int k = 0; k < NumColumns; k++)
				{
					array[i, j] += double_0[i, k] * inMatrix.Values[k, j];
				}
			}
		}
		return new MatrixD(array);
	}

	IMatrix IMatrix.Multiply(IMatrix inMatrix)
	{
		if (!(inMatrix is IMatrixD inMatrix2))
		{
			throw new ArgumentException("Invalid Matrix provided for inMatrix");
		}
		return Multiply(inMatrix2);
	}

	public IMatrixD Multiply(double inScalar)
	{
		double[,] array = new double[NumRows, NumColumns];
		for (int i = 0; i < NumRows; i++)
		{
			for (int j = 0; j < NumColumns; j++)
			{
				array[i, j] = double_0[i, j] * inScalar;
			}
		}
		return new MatrixD(array);
	}

	static MatrixD()
	{
		Class72.smethod_20();
	}
}
