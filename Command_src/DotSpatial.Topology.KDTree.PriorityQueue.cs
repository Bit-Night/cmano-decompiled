using System;

namespace DotSpatial.Topology.KDTree;

internal class PriorityQueue
{
	private readonly double double_0 = 1.79769E+30;

	private int int_0;

	private int int_1;

	private object[] object_0;

	private double[] double_1;

	public PriorityQueue()
	{
		method_0(20);
	}

	public PriorityQueue(int capacity)
	{
		method_0(capacity);
	}

	public PriorityQueue(int capacity, double maxPriority)
	{
		double_0 = maxPriority;
		method_0(capacity);
	}

	private void method_0(int int_2)
	{
		int_0 = int_2;
		object_0 = new object[int_0 + 1];
		double_1 = new double[int_0 + 1];
		double_1[0] = double_0;
		object_0[0] = null;
	}

	public void Add(object element, double priority)
	{
		if (int_1++ >= int_0)
		{
			method_3();
		}
		double_1[int_1] = priority;
		object_0[int_1] = element;
		method_2(int_1);
	}

	public object Remove()
	{
		if (int_1 == 0)
		{
			return null;
		}
		object result = object_0[1];
		object_0[1] = object_0[int_1];
		double_1[1] = double_1[int_1];
		object_0[int_1] = null;
		double_1[int_1] = 0.0;
		int_1--;
		method_1(1);
		return result;
	}

	public object Front()
	{
		return object_0[1];
	}

	public double GetMaxPriority()
	{
		return double_1[1];
	}

	private void method_1(int int_2)
	{
		object obj = object_0[int_2];
		double num = double_1[int_2];
		while (int_2 * 2 <= int_1)
		{
			int num2 = int_2 * 2;
			if (num2 != int_1 && double_1[num2] < double_1[num2 + 1])
			{
				num2++;
			}
			if (!(num < double_1[num2]))
			{
				break;
			}
			double_1[int_2] = double_1[num2];
			object_0[int_2] = object_0[num2];
			int_2 = num2;
		}
		double_1[int_2] = num;
		object_0[int_2] = obj;
	}

	private void method_2(int int_2)
	{
		object obj = object_0[int_2];
		double num = double_1[int_2];
		while (double_1[int_2 / 2] < num)
		{
			double_1[int_2] = double_1[int_2 / 2];
			object_0[int_2] = object_0[int_2 / 2];
			int_2 /= 2;
		}
		double_1[int_2] = num;
		object_0[int_2] = obj;
	}

	private void method_3()
	{
		int_0 = int_1 * 2;
		object[] destinationArray = new object[int_0 + 1];
		double[] destinationArray2 = new double[int_0 + 1];
		Array.Copy(object_0, 0, destinationArray, 0, object_0.Length);
		Array.Copy(double_1, 0, destinationArray2, 0, object_0.Length);
		object_0 = destinationArray;
		double_1 = destinationArray2;
	}

	public void Clear()
	{
		for (int i = 1; i < int_1; i++)
		{
			object_0[i] = null;
		}
		int_1 = 0;
	}

	public int Length()
	{
		return int_1;
	}

	static PriorityQueue()
	{
		Class72.smethod_20();
	}
}
