using System;
using Collections.Pooled;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class ArrayExtensions
{
	public static void Add<T>(this ref T[] theArray, T theAC)
	{
		Array.Resize(ref theArray, theArray.Length + 1);
		theArray[theArray.Length - 1] = theAC;
	}

	public static void Remove<T>(this ref T[] theArray, T value)
	{
		int num = Array.IndexOf(theArray, value);
		if (num < 0)
		{
			return;
		}
		if (theArray.Length == 1)
		{
			theArray = Array.Empty<T>();
			return;
		}
		T[] array = new T[theArray.Length - 2 + 1];
		if (num > 0)
		{
			Array.Copy(theArray, 0, array, 0, num);
		}
		if (num < theArray.Length - 1)
		{
			Array.Copy(theArray, num + 1, array, num, theArray.Length - num - 1);
		}
		theArray = array;
	}

	public static void RemoveAT<T>(this ref T[] theArray, int theIndex)
	{
		lock (theArray)
		{
			if (theArray.Length == 1 && theIndex > -1)
			{
				T[] array = new T[0];
				theArray = array;
				return;
			}
			PooledList<T> pooledList = new PooledList<T>(theArray, Pools<T>.Local);
			pooledList.RemoveAt(theIndex);
			theArray = pooledList.ToArray();
			pooledList.Dispose();
		}
	}

	public static void Clear<T>(this ref T[] theArray)
	{
		lock (theArray)
		{
			theArray = new T[0];
		}
	}

	public static void Insert<T>(this ref T[] theArray, int IndexOfInsert, T theW)
	{
		lock (theArray)
		{
			PooledList<T> pooledList = new PooledList<T>(theArray, Pools<T>.Local);
			pooledList.Insert(IndexOfInsert, theW);
			theArray = pooledList.ToArray();
			pooledList.Dispose();
		}
	}

	public static T[] Join<T>(this ref T[] Array1, ref T[] Array2)
	{
		T[] array = new T[Array1.Length + Array2.Length - 1 + 1];
		Array1.CopyTo(array, 0);
		Array2.CopyTo(array, Array1.Length);
		return array;
	}

	static ArrayExtensions()
	{
		Class72.smethod_20();
	}
}
