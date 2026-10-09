using System;

public static class ArrayIteratorExtensions
{
	public static ArrayIterator<T> Begin<T>(this T[] array)
	{
		return new ArrayIterator<T>
		{
			Array = array
		};
	}

	public static ArrayIterator<T> End<T>(this T[] array)
	{
		return new ArrayIterator<T>
		{
			Array = array,
			Index = array.Length
		};
	}

	public static ArrayIterator<T> IteratorAt<T>(this T[] array, int index)
	{
		return new ArrayIterator<T>
		{
			Array = array,
			Index = index
		};
	}

	public static T GetCurrent<T>(this ArrayIterator<T> it)
	{
		return it.Array[it.Index];
	}

	public static void SetCurrent<T>(this ArrayIterator<T> it, T val)
	{
		it.Array[it.Index] = val;
	}

	public static ArrayIterator<T> GetNext<T>(this ArrayIterator<T> it)
	{
		it.Index++;
		return it;
	}

	public static ArrayIterator<T> GetPrev<T>(this ArrayIterator<T> it)
	{
		it.Index--;
		return it;
	}

	public static bool IsEqual<T>(this ArrayIterator<T> it, ArrayIterator<T> other)
	{
		if (it.Array == other.Array)
		{
			return it.Index == other.Index;
		}
		return false;
	}

	public static bool NotEqual<T>(this ArrayIterator<T> it, ArrayIterator<T> other)
	{
		if (it.Array == other.Array)
		{
			return it.Index != other.Index;
		}
		return true;
	}

	public static ArrayIterator<T> GetAdvanced<T>(this ArrayIterator<T> it, int distance)
	{
		return new ArrayIterator<T>
		{
			Array = it.Array,
			Index = it.Index + distance
		};
	}

	public static int Distance<T>(this ArrayIterator<T> first, ArrayIterator<T> last)
	{
		return last.Index - first.Index;
	}

	public static bool AllOf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		while (true)
		{
			if (first.NotEqual(last))
			{
				if (!pred(first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool AnyOf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		while (true)
		{
			if (first.NotEqual(last))
			{
				if (pred(first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool NoneOf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		while (true)
		{
			if (first.NotEqual(last))
			{
				if (pred(first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static void ForEach<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Action<T> callback)
	{
		while (first.NotEqual(last))
		{
			callback(first.GetCurrent());
			first = first.GetNext();
		}
	}

	public static ArrayIterator<T> Find<T>(this ArrayIterator<T> first, ArrayIterator<T> last, T val, Func<T, T, bool> pred)
	{
		while (true)
		{
			if (first.NotEqual(last))
			{
				if (pred(first.GetCurrent(), val))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return last;
		}
		return first;
	}

	public static ArrayIterator<T> FindIf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		while (true)
		{
			if (first.NotEqual(last))
			{
				if (pred(first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return last;
		}
		return first;
	}

	public static ArrayIterator<T> FindIfNot<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		while (true)
		{
			if (first.NotEqual(last))
			{
				if (!pred(first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return last;
		}
		return first;
	}

	public static ArrayIterator<T> FindEnd<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, Func<T, T, bool> pred)
	{
		if (first2.IsEqual(last2))
		{
			return last1;
		}
		ArrayIterator<T> result = last1;
		while (first1.NotEqual(last1))
		{
			ArrayIterator<T> it = first1;
			ArrayIterator<T> it2 = first2;
			while (pred(it.GetCurrent(), it2.GetCurrent()))
			{
				it = it.GetNext();
				it2 = it2.GetNext();
				if (!it2.IsEqual(last2))
				{
					if (it.IsEqual(last1))
					{
						return result;
					}
					continue;
				}
				result = first1;
				break;
			}
			first1 = first1.GetNext();
		}
		return result;
	}

	public static ArrayIterator<T> FindFirstOf<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, Func<T, T, bool> pred)
	{
		while (first1.NotEqual(last1))
		{
			ArrayIterator<T> it = first2;
			while (it.NotEqual(last2))
			{
				if (!pred(it.GetCurrent(), first1.GetCurrent()))
				{
					it = it.GetNext();
					continue;
				}
				return first1;
			}
			first1 = first1.GetNext();
		}
		return last1;
	}

	public static ArrayIterator<T> AdjacentFind<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> pred)
	{
		if (first.NotEqual(last))
		{
			ArrayIterator<T> it = first;
			it = it.GetNext();
			while (it.NotEqual(last))
			{
				if (!pred(first.GetCurrent(), it.GetCurrent()))
				{
					first = first.GetNext();
					it = it.GetNext();
					continue;
				}
				return first;
			}
		}
		return last;
	}

	public static int Count<T>(this ArrayIterator<T> first, ArrayIterator<T> last, T val, Func<T, T, bool> pred)
	{
		int num = 0;
		while (first.NotEqual(last))
		{
			if (pred(first.GetCurrent(), val))
			{
				num++;
			}
			first = first.GetNext();
		}
		return num;
	}

	public static int CountIf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		int num = 0;
		while (first.NotEqual(last))
		{
			if (pred(first.GetCurrent()))
			{
				num++;
			}
			first = first.GetNext();
		}
		return num;
	}

	public static void Mismatch<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, Func<T, T, bool> pred, out ArrayIterator<T> mismatch1, out ArrayIterator<T> mismatch2)
	{
		while (first1.NotEqual(last1) && pred(first1.GetCurrent(), first2.GetCurrent()))
		{
			first1 = first1.GetNext();
			first2 = first2.GetNext();
		}
		mismatch1 = first1;
		mismatch2 = first2;
	}

	public static bool Equal<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, Func<T, T, bool> pred)
	{
		while (true)
		{
			if (first1.NotEqual(last1))
			{
				if (!pred(first1.GetCurrent(), first2.GetCurrent()))
				{
					break;
				}
				first1 = first1.GetNext();
				first2 = first2.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool IsPermutation<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, Func<T, T, bool> pred)
	{
		first1.Mismatch(last1, first2, pred, out first1, out first2);
		if (first1.IsEqual(last1))
		{
			return true;
		}
		ArrayIterator<T> it = first2;
		it = it.GetAdvanced(first1.Distance(last1));
		ArrayIterator<T> arrayIterator = first1;
		while (true)
		{
			if (arrayIterator.NotEqual(last1))
			{
				if (first1.Find(arrayIterator, arrayIterator.GetCurrent(), pred).IsEqual(arrayIterator))
				{
					int num = first2.Count(it, arrayIterator.GetCurrent(), pred);
					if (num == 0 || arrayIterator.Count(last1, arrayIterator.GetCurrent(), pred) != num)
					{
						break;
					}
				}
				arrayIterator = arrayIterator.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static ArrayIterator<T> Search<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, Func<T, T, bool> pred)
	{
		if (first2.IsEqual(last2))
		{
			return first1;
		}
		while (first1.NotEqual(last1))
		{
			ArrayIterator<T> it = first1;
			ArrayIterator<T> it2 = first2;
			while (pred(it.GetCurrent(), it2.GetCurrent()))
			{
				it = it.GetNext();
				it2 = it2.GetNext();
				if (!it2.IsEqual(last2))
				{
					if (it.IsEqual(last1))
					{
						return last1;
					}
					continue;
				}
				return first1;
			}
			first1 = first1.GetNext();
		}
		return last1;
	}

	public static ArrayIterator<T> SearchN<T>(this ArrayIterator<T> first, ArrayIterator<T> last, int count, T val, Func<T, T, bool> pred)
	{
		ArrayIterator<T> advanced = first.GetAdvanced(first.Distance(last) - count);
		while (first.NotEqual(advanced))
		{
			ArrayIterator<T> it = first;
			int num = 0;
			while (pred(val, it.GetCurrent()))
			{
				it = it.GetNext();
				if (++num == count)
				{
					return first;
				}
			}
			first = first.GetNext();
		}
		return last;
	}

	public static ArrayIterator<T> Copy<T>(this ArrayIterator<T> first, ArrayIterator<T> last, ArrayIterator<T> result)
	{
		while (first.NotEqual(last))
		{
			result.SetCurrent(first.GetCurrent());
			result = result.GetNext();
			first = first.GetNext();
		}
		return result;
	}

	public static ArrayIterator<T> CopyN<T>(this ArrayIterator<T> first, int n, ArrayIterator<T> result)
	{
		while (n > 0)
		{
			result.SetCurrent(first.GetCurrent());
			result = result.GetNext();
			first = first.GetNext();
			n--;
		}
		return result;
	}

	public static ArrayIterator<T> CopyIf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, ArrayIterator<T> result, Func<T, bool> pred)
	{
		while (first.NotEqual(last))
		{
			if (pred(first.GetCurrent()))
			{
				result.SetCurrent(first.GetCurrent());
				result = result.GetNext();
			}
			first = first.GetNext();
		}
		return result;
	}

	public static ArrayIterator<T> CopyBackward<T>(this ArrayIterator<T> first, ArrayIterator<T> last, ArrayIterator<T> result)
	{
		while (last.NotEqual(first))
		{
			result = result.GetPrev();
			last = last.GetPrev();
			result.SetCurrent(last.GetCurrent());
		}
		return result;
	}

	public static ArrayIterator<T> SwapRanges<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2)
	{
		while (first1.NotEqual(last1))
		{
			first1.Swap(first2);
			first1 = first1.GetNext();
			first2 = first2.GetNext();
		}
		return first2;
	}

	public static void Swap<T>(this ArrayIterator<T> a, ArrayIterator<T> b)
	{
		T current = a.GetCurrent();
		a.SetCurrent(b.GetCurrent());
		b.SetCurrent(current);
	}

	public static ArrayIterator<T> Transform<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> result, Func<T, T> op)
	{
		while (first1.NotEqual(last1))
		{
			result.SetCurrent(op(first1.GetCurrent()));
			result = result.GetNext();
			first1 = first1.GetNext();
		}
		return result;
	}

	public static ArrayIterator<T> Transform<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> result, Func<T, T, T> binaryOp)
	{
		while (first1.NotEqual(last1))
		{
			result.SetCurrent(binaryOp(first1.GetCurrent(), first2.GetCurrent()));
			first2 = first2.GetNext();
			result = result.GetNext();
			first1 = first1.GetNext();
		}
		return result;
	}

	public static void ReplaceIf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred, T newValue)
	{
		while (first.NotEqual(last))
		{
			if (pred(first.GetCurrent()))
			{
				first.SetCurrent(newValue);
			}
			first = first.GetNext();
		}
	}

	public static ArrayIterator<T> ReplaceCopyIf<T>(this ArrayIterator<T> first, ArrayIterator<T> last, ArrayIterator<T> result, Func<T, bool> pred, T newValue)
	{
		while (first.NotEqual(last))
		{
			result.SetCurrent(pred(first.GetCurrent()) ? newValue : first.GetCurrent());
			first = first.GetNext();
			result = result.GetNext();
		}
		return result;
	}

	public static ArrayIterator<T> Unique<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> pred)
	{
		if (first.IsEqual(last))
		{
			return last;
		}
		ArrayIterator<T> it = first;
		while ((first = first.GetNext()).NotEqual(last))
		{
			if (!pred(it.GetCurrent(), first.GetCurrent()))
			{
				it = it.GetNext();
				it.SetCurrent(first.GetCurrent());
			}
		}
		return it.GetNext();
	}

	public static ArrayIterator<T> UniqueCopy<T>(this ArrayIterator<T> first, ArrayIterator<T> last, ArrayIterator<T> result, Func<T, T, bool> pred)
	{
		if (first.IsEqual(last))
		{
			return last;
		}
		result.SetCurrent(first.GetCurrent());
		while ((first = first.GetNext()).NotEqual(last))
		{
			T current = first.GetCurrent();
			if (!pred(result.GetCurrent(), current))
			{
				result = result.GetNext();
				result.SetCurrent(current);
			}
		}
		result = result.GetNext();
		return result;
	}

	public static void Reverse<T>(this ArrayIterator<T> first, ArrayIterator<T> last)
	{
		while (first.NotEqual(last) && first.NotEqual(last = last.GetPrev()))
		{
			first.Swap(last);
			first = first.GetNext();
		}
	}

	public static ArrayIterator<T> ReverseCopy<T>(this ArrayIterator<T> first, ArrayIterator<T> last, ArrayIterator<T> result)
	{
		while (first.NotEqual(last))
		{
			last = last.GetPrev();
			result.SetCurrent(last.GetCurrent());
			result = result.GetNext();
		}
		return result;
	}

	public static void Rotate<T>(this ArrayIterator<T> first, ArrayIterator<T> middle, ArrayIterator<T> last)
	{
		ArrayIterator<T> arrayIterator = middle;
		while (first.NotEqual(last))
		{
			first.Swap(arrayIterator);
			first = first.GetNext();
			arrayIterator = arrayIterator.GetNext();
			if (arrayIterator.IsEqual(last))
			{
				arrayIterator = middle;
			}
			else if (first.IsEqual(middle))
			{
				middle = arrayIterator;
			}
		}
	}

	public static ArrayIterator<T> RotateCopy<T>(this ArrayIterator<T> first, ArrayIterator<T> middle, ArrayIterator<T> last, ArrayIterator<T> result)
	{
		result = middle.Copy(last, result);
		return first.Copy(middle, result);
	}

	public static void RandomShuffle<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<int, int> gen)
	{
		for (int num = first.Distance(last) - 1; num > 0; num--)
		{
			first.GetAdvanced(num).Swap(first.GetAdvanced(gen(num + 1)));
		}
	}

	public static bool IsPartitioned<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		while (first.NotEqual(last) && pred(first.GetCurrent()))
		{
			first = first.GetNext();
		}
		while (true)
		{
			if (first.NotEqual(last))
			{
				if (pred(first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static ArrayIterator<T> Partition<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		while (first.NotEqual(last))
		{
			while (pred(first.GetCurrent()))
			{
				first = first.GetNext();
				if (first.IsEqual(last))
				{
					return first;
				}
			}
			do
			{
				last = last.GetPrev();
				if (first.IsEqual(last))
				{
					return first;
				}
			}
			while (!pred(last.GetCurrent()));
			first.Swap(last);
			first = first.GetNext();
		}
		return first;
	}

	public static void PartitionCopy<T>(this ArrayIterator<T> first, ArrayIterator<T> last, ArrayIterator<T> resultTrue, ArrayIterator<T> resultFalse, Func<T, bool> pred, out ArrayIterator<T> outResultTrue, out ArrayIterator<T> outResultFalse)
	{
		while (first.NotEqual(last))
		{
			if (pred(first.GetCurrent()))
			{
				resultTrue.SetCurrent(first.GetCurrent());
				resultTrue = resultTrue.GetNext();
			}
			else
			{
				resultFalse.SetCurrent(first.GetCurrent());
				resultFalse = resultFalse.GetNext();
			}
			first = first.GetNext();
		}
		outResultTrue = resultTrue;
		outResultFalse = resultFalse;
	}

	public static ArrayIterator<T> PartitionPoint<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, bool> pred)
	{
		int num = first.Distance(last);
		while (num > 0)
		{
			ArrayIterator<T> it = first;
			int num2 = num / 2;
			it.GetAdvanced(num2);
			if (pred(it.GetCurrent()))
			{
				first = it.GetNext();
				num -= num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return first;
	}

	public static void Sort<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return;
		}
		ArrayIterator<T> arrayIterator = first;
		ArrayIterator<T> next = first.GetNext();
		while (next.NotEqual(last))
		{
			if (comp(next.GetCurrent(), first.GetCurrent()))
			{
				arrayIterator = arrayIterator.GetNext();
				arrayIterator.Swap(next);
			}
			next = next.GetNext();
		}
		first.Swap(arrayIterator);
		first.Sort(arrayIterator, comp);
		arrayIterator.GetNext().Sort(last, comp);
	}

	public static void StableSort<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		T[] array = first.Array;
		for (int i = first.Index + 1; i < last.Index; i++)
		{
			T val = array[i];
			int num = first.Index;
			int num2 = i - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				if (comp(val, array[num3]))
				{
					num2 = num3 - 1;
				}
				else
				{
					num = num3 + 1;
				}
			}
			for (int num4 = i - 1; num4 >= num; num4--)
			{
				array[num4 + 1] = array[num4];
			}
			array[num] = val;
		}
	}

	public static void PartialSort<T>(this ArrayIterator<T> first, ArrayIterator<T> middle, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		first.Sort(last, comp);
	}

	public static bool IsSorted<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return true;
		}
		ArrayIterator<T> it = first;
		while (true)
		{
			if ((it = it.GetNext()).NotEqual(last))
			{
				if (comp(it.GetCurrent(), first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static ArrayIterator<T> IsSortedUntil<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return first;
		}
		ArrayIterator<T> arrayIterator = first;
		while (true)
		{
			if ((arrayIterator = arrayIterator.GetNext()).NotEqual(last))
			{
				if (comp(arrayIterator.GetCurrent(), first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return last;
		}
		return arrayIterator;
	}

	public static void NthElement<T>(this ArrayIterator<T> first, ArrayIterator<T> nth, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		first.Sort(last, comp);
	}

	public static ArrayIterator<T> LowerBound<T>(this ArrayIterator<T> first, ArrayIterator<T> last, T val, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		while (num > 0)
		{
			ArrayIterator<T> it = first;
			int num2 = num / 2;
			it = it.GetAdvanced(num2);
			if (comp(it.GetCurrent(), val))
			{
				it = it.GetNext();
				first = it;
				num -= num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return first;
	}

	public static ArrayIterator<T> UpperBound<T>(this ArrayIterator<T> first, ArrayIterator<T> last, T val, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		while (num > 0)
		{
			ArrayIterator<T> it = first;
			int num2 = num / 2;
			it = it.GetAdvanced(num2);
			if (!comp(val, it.GetCurrent()))
			{
				it = it.GetNext();
				first = it;
				num -= num2 + 1;
			}
			else
			{
				num = num2;
			}
		}
		return first;
	}

	public static void EqualRange<T>(this ArrayIterator<T> first, ArrayIterator<T> last, T val, Func<T, T, bool> comp, out ArrayIterator<T> lower, out ArrayIterator<T> upper)
	{
		lower = first.LowerBound(last, val, comp);
		upper = lower.UpperBound(last, val, comp);
	}

	public static bool BinarySearch<T>(this ArrayIterator<T> first, ArrayIterator<T> last, T val, Func<T, T, bool> comp)
	{
		first = first.LowerBound(last, val, comp);
		if (first.NotEqual(last))
		{
			return !comp(val, first.GetCurrent());
		}
		return false;
	}

	public static ArrayIterator<T> Merge<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, ArrayIterator<T> result, Func<T, T, bool> comp)
	{
		while (true)
		{
			if (!first1.IsEqual(last1))
			{
				if (first2.IsEqual(last2))
				{
					break;
				}
				if (comp(first2.GetCurrent(), first1.GetCurrent()))
				{
					result.SetCurrent(first2.GetCurrent());
					first2 = first2.GetNext();
				}
				else
				{
					result.SetCurrent(first1.GetCurrent());
					first1 = first1.GetNext();
				}
				result = result.GetNext();
				continue;
			}
			return first2.Copy(last2, result);
		}
		return first1.Copy(last1, result);
	}

	public static void InplaceMerge<T>(this ArrayIterator<T> first, ArrayIterator<T> middle, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.Index >= middle.Index || middle.Index >= last.Index)
		{
			return;
		}
		if (last.Index - first.Index == 2)
		{
			if (comp(middle.GetCurrent(), first.GetCurrent()))
			{
				first.Swap(middle);
			}
			return;
		}
		ArrayIterator<T> arrayIterator;
		ArrayIterator<T> arrayIterator2;
		if (middle.Index - first.Index > last.Index - middle.Index)
		{
			arrayIterator = first.GetAdvanced(first.Distance(middle) / 2);
			arrayIterator2 = middle.LowerBound(last, arrayIterator.GetCurrent(), comp);
		}
		else
		{
			arrayIterator2 = middle.GetAdvanced(middle.Distance(last) / 2);
			arrayIterator = first.UpperBound(middle, arrayIterator2.GetCurrent(), comp);
		}
		arrayIterator.Rotate(middle, arrayIterator2);
		middle = arrayIterator.GetAdvanced(middle.Distance(arrayIterator2));
		first.InplaceMerge(arrayIterator, middle, comp);
		middle.InplaceMerge(arrayIterator2, last, comp);
	}

	public static bool Includes<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, Func<T, T, bool> comp)
	{
		while (true)
		{
			if (first2.NotEqual(last2))
			{
				if (first1.IsEqual(last1) || comp(first2.GetCurrent(), first1.GetCurrent()))
				{
					break;
				}
				if (!comp(first1.GetCurrent(), first2.GetCurrent()))
				{
					first2 = first2.GetNext();
				}
				first1 = first1.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static ArrayIterator<T> SetUnion<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, ArrayIterator<T> result, Func<T, T, bool> comp)
	{
		while (true)
		{
			if (!first1.IsEqual(last1))
			{
				if (first2.IsEqual(last2))
				{
					break;
				}
				if (comp(first1.GetCurrent(), first2.GetCurrent()))
				{
					result.SetCurrent(first1.GetCurrent());
					first1 = first1.GetNext();
				}
				else if (comp(first2.GetCurrent(), first1.GetCurrent()))
				{
					result.SetCurrent(first2.GetCurrent());
					first2 = first2.GetNext();
				}
				else
				{
					result.SetCurrent(first1.GetCurrent());
					first1 = first1.GetNext();
					first2 = first2.GetNext();
				}
				result = result.GetNext();
				continue;
			}
			return first2.Copy(last2, result);
		}
		return first1.Copy(last1, result);
	}

	public static ArrayIterator<T> SetIntersection<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, ArrayIterator<T> result, Func<T, T, bool> comp)
	{
		while (first1.NotEqual(last1) && first2.NotEqual(last2))
		{
			if (comp(first1.GetCurrent(), first2.GetCurrent()))
			{
				first1 = first1.GetNext();
				continue;
			}
			if (comp(first2.GetCurrent(), first1.GetCurrent()))
			{
				first2 = first2.GetNext();
				continue;
			}
			result.SetCurrent(first1.GetCurrent());
			result = result.GetNext();
			first1 = first1.GetNext();
			first2 = first2.GetNext();
		}
		return result;
	}

	public static ArrayIterator<T> SetDifference<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, ArrayIterator<T> result, Func<T, T, bool> comp)
	{
		while (first1.NotEqual(last1) && first2.NotEqual(last2))
		{
			if (comp(first1.GetCurrent(), first2.GetCurrent()))
			{
				result.SetCurrent(first1.GetCurrent());
				result = result.GetNext();
				first1 = first1.GetNext();
			}
			else if (comp(first2.GetCurrent(), first1.GetCurrent()))
			{
				first2 = first2.GetNext();
			}
			else
			{
				first1 = first1.GetNext();
				first2 = first2.GetNext();
			}
		}
		return first1.Copy(last1, result);
	}

	public static ArrayIterator<T> SetSymmetricDifference<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, ArrayIterator<T> result, Func<T, T, bool> comp)
	{
		while (true)
		{
			if (!first1.IsEqual(last1))
			{
				if (first2.IsEqual(last2))
				{
					break;
				}
				if (comp(first1.GetCurrent(), first2.GetCurrent()))
				{
					result.SetCurrent(first1.GetCurrent());
					result = result.GetNext();
					first1 = first1.GetNext();
				}
				else if (comp(first2.GetCurrent(), first1.GetCurrent()))
				{
					result.SetCurrent(first2.GetCurrent());
					result = result.GetNext();
					first2 = first2.GetNext();
				}
				else
				{
					first1 = first1.GetNext();
					first2 = first2.GetNext();
				}
				continue;
			}
			return first2.Copy(last2, result);
		}
		return first1.Copy(last1, result);
	}

	public static void PushHeap<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.Distance(last) >= 2)
		{
			last = last.GetPrev();
			T current = last.GetCurrent();
			ArrayIterator<T> advanced = first.GetAdvanced((first.Distance(last) - 1) / 2);
			while (first.Distance(last) > 0 && comp(advanced.GetCurrent(), current))
			{
				last.SetCurrent(advanced.GetCurrent());
				last = advanced;
				advanced = first.GetAdvanced((first.Distance(last) - 1) / 2);
			}
			last.SetCurrent(current);
		}
	}

	public static void PopHeap<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.Distance(last) >= 2)
		{
			last = last.GetPrev();
			first.Swap(last);
			first.Array.smethod_0(first.Index, first.Index, last.Index, comp);
		}
	}

	public static void MakeHeap<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		if (num >= 2)
		{
			int num2 = (num - 2) / 2;
			do
			{
				first.Array.smethod_0(first.Index, first.Index + num2, last.Index, comp);
			}
			while (num2-- != 0);
		}
	}

	public static void SortHeap<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		while (first.Distance(last) > 1)
		{
			last = last.GetPrev();
			first.Swap(last);
			first.Array.smethod_0(first.Index, first.Index, last.Index, comp);
		}
	}

	public static ArrayIterator<T> MinElement<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return last;
		}
		ArrayIterator<T> arrayIterator = first;
		while ((first = first.GetNext()).NotEqual(last))
		{
			if (comp(first.GetCurrent(), arrayIterator.GetCurrent()))
			{
				arrayIterator = first;
			}
		}
		return arrayIterator;
	}

	public static ArrayIterator<T> MaxElement<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return last;
		}
		ArrayIterator<T> arrayIterator = first;
		while ((first = first.GetNext()).NotEqual(last))
		{
			if (comp(arrayIterator.GetCurrent(), first.GetCurrent()))
			{
				arrayIterator = first;
			}
		}
		return arrayIterator;
	}

	public static void MinMaxElement<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp, out ArrayIterator<T> min, out ArrayIterator<T> max)
	{
		if (first.IsEqual(last))
		{
			min = last;
			max = last;
		}
		min = first;
		max = first;
		while ((first = first.GetNext()).NotEqual(last))
		{
			if (comp(first.GetCurrent(), min.GetCurrent()))
			{
				min = first;
			}
			if (comp(max.GetCurrent(), first.GetCurrent()))
			{
				max = first;
			}
		}
	}

	public static bool LexicographicalCompare<T>(this ArrayIterator<T> first1, ArrayIterator<T> last1, ArrayIterator<T> first2, ArrayIterator<T> last2, Func<T, T, bool> comp)
	{
		while (true)
		{
			if (first1.NotEqual(last1))
			{
				if (first2.IsEqual(last2) || comp(first2.GetCurrent(), first1.GetCurrent()))
				{
					break;
				}
				if (!comp(first1.GetCurrent(), first2.GetCurrent()))
				{
					first1 = first1.GetNext();
					first2 = first2.GetNext();
					continue;
				}
				return true;
			}
			return first2.NotEqual(last2);
		}
		return false;
	}

	public static bool NextPermutation<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		ArrayIterator<T> it = last;
		if (!first.IsEqual(last) && !first.IsEqual(it = it.GetPrev()))
		{
			do
			{
				ArrayIterator<T> arrayIterator = it;
				if (comp((it = it.GetPrev()).GetCurrent(), arrayIterator.GetCurrent()))
				{
					ArrayIterator<T> arrayIterator2 = last;
					while (!comp(it.GetCurrent(), (arrayIterator2 = arrayIterator2.GetPrev()).GetCurrent()))
					{
					}
					it.Swap(arrayIterator2);
					arrayIterator.Reverse(last);
					return true;
				}
			}
			while (!it.IsEqual(first));
			first.Reverse(last);
			return false;
		}
		return false;
	}

	public static bool PrevPermutation<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		ArrayIterator<T> it = last;
		if (!first.IsEqual(last) && !first.IsEqual(it = it.GetPrev()))
		{
			do
			{
				ArrayIterator<T> arrayIterator = it;
				if (comp(arrayIterator.GetCurrent(), (it = it.GetPrev()).GetCurrent()))
				{
					ArrayIterator<T> arrayIterator2 = last;
					while (!comp((arrayIterator2 = arrayIterator2.GetPrev()).GetCurrent(), it.GetCurrent()))
					{
					}
					it.Swap(arrayIterator2);
					arrayIterator.Reverse(last);
					return true;
				}
			}
			while (!it.IsEqual(first));
			first.Reverse(last);
			return false;
		}
		return false;
	}

	private static void smethod_0<T>(this object object_0, int int_0, int int_1, int int_2, Func<T, T, bool> func_0)
	{
		T val = ((T[])object_0)[int_1];
		int num = int_2 - int_0;
		int num2 = int_1 - int_0;
		int num3;
		for (num3 = 2 * num2 + 2; num3 < num; num3 *= 2)
		{
			if (func_0(((T[])object_0)[int_0 + num3], ((T[])object_0)[int_0 + (num3 - 1)]))
			{
				num3--;
			}
			((T[])object_0)[int_0 + num2] = ((T[])object_0)[int_0 + num3];
			num2 = num3++;
		}
		if (num3-- == num)
		{
			((T[])object_0)[int_0 + num2] = ((T[])object_0)[int_0 + num3];
			num2 = num3;
		}
		int num4 = (num2 - 1) / 2;
		int num5 = int_1 - int_0;
		while (num2 != num5 && func_0(((T[])object_0)[int_0 + num4], val))
		{
			((T[])object_0)[int_0 + num2] = ((T[])object_0)[int_0 + num4];
			num2 = num4;
			num4 = (num2 - 1) / 2;
		}
		((T[])object_0)[int_0 + num2] = val;
	}

	public static bool IsHeap<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		return first.IsHeapUntil(last, comp).IsEqual(last);
	}

	public static ArrayIterator<T> IsHeapUntil<T>(this ArrayIterator<T> first, ArrayIterator<T> last, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		int num2 = 0;
		int num3 = 1;
		ArrayIterator<T> it = first;
		ArrayIterator<T> advanced;
		while (true)
		{
			if (num3 < num)
			{
				advanced = first.GetAdvanced(num3);
				if (comp(it.GetCurrent(), advanced.GetCurrent()))
				{
					break;
				}
				num3++;
				advanced = advanced.GetNext();
				if (num3 != num)
				{
					if (!comp(it.GetCurrent(), advanced.GetCurrent()))
					{
						num2++;
						it = it.GetNext();
						num3 = 2 * num2 + 1;
						continue;
					}
					return advanced;
				}
				return last;
			}
			return last;
		}
		return advanced;
	}

	static ArrayIteratorExtensions()
	{
		Class72.smethod_20();
	}
}
