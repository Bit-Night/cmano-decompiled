using System;
using System.Collections.Generic;

public static class ListIteratorExtensions
{
	public static ListIterator<T> Begin<T>(this IList<T> list)
	{
		return new ListIterator<T>
		{
			List = list
		};
	}

	public static ListIterator<T> End<T>(this IList<T> list)
	{
		return new ListIterator<T>
		{
			List = list,
			Index = list.Count
		};
	}

	public static ListIterator<T> IteratorAt<T>(this IList<T> list, int index)
	{
		return new ListIterator<T>
		{
			List = list,
			Index = index
		};
	}

	public static T GetCurrent<T>(this ListIterator<T> it)
	{
		return it.List[it.Index];
	}

	public static void SetCurrent<T>(this ListIterator<T> it, T val)
	{
		it.List[it.Index] = val;
	}

	public static ListIterator<T> GetNext<T>(this ListIterator<T> it)
	{
		it.Index++;
		return it;
	}

	public static ListIterator<T> GetPrev<T>(this ListIterator<T> it)
	{
		it.Index--;
		return it;
	}

	public static bool IsEqual<T>(this ListIterator<T> it, ListIterator<T> other)
	{
		if (it.List == other.List)
		{
			return it.Index == other.Index;
		}
		return false;
	}

	public static bool NotEqual<T>(this ListIterator<T> it, ListIterator<T> other)
	{
		if (it.List == other.List)
		{
			return it.Index != other.Index;
		}
		return true;
	}

	public static ListIterator<T> GetAdvanced<T>(this ListIterator<T> it, int distance)
	{
		return new ListIterator<T>
		{
			List = it.List,
			Index = it.Index + distance
		};
	}

	public static int Distance<T>(this ListIterator<T> first, ListIterator<T> last)
	{
		return last.Index - first.Index;
	}

	public static bool AllOf<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static bool AnyOf<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static bool NoneOf<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static void ForEach<T>(this ListIterator<T> first, ListIterator<T> last, Action<T> callback)
	{
		while (first.NotEqual(last))
		{
			callback(first.GetCurrent());
			first = first.GetNext();
		}
	}

	public static ListIterator<T> Find<T>(this ListIterator<T> first, ListIterator<T> last, T val, Func<T, T, bool> pred)
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

	public static ListIterator<T> FindIf<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static ListIterator<T> FindIfNot<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static ListIterator<T> FindEnd<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, Func<T, T, bool> pred)
	{
		if (first2.IsEqual(last2))
		{
			return last1;
		}
		ListIterator<T> result = last1;
		while (first1.NotEqual(last1))
		{
			ListIterator<T> it = first1;
			ListIterator<T> it2 = first2;
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

	public static ListIterator<T> FindFirstOf<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, Func<T, T, bool> pred)
	{
		while (first1.NotEqual(last1))
		{
			ListIterator<T> it = first2;
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

	public static ListIterator<T> AdjacentFind<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> pred)
	{
		if (first.NotEqual(last))
		{
			ListIterator<T> it = first;
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

	public static int Count<T>(this ListIterator<T> first, ListIterator<T> last, T val, Func<T, T, bool> pred)
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

	public static int CountIf<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static void Mismatch<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, Func<T, T, bool> pred, out ListIterator<T> mismatch1, out ListIterator<T> mismatch2)
	{
		while (first1.NotEqual(last1) && pred(first1.GetCurrent(), first2.GetCurrent()))
		{
			first1 = first1.GetNext();
			first2 = first2.GetNext();
		}
		mismatch1 = first1;
		mismatch2 = first2;
	}

	public static bool Equal<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, Func<T, T, bool> pred)
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

	public static bool IsPermutation<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, Func<T, T, bool> pred)
	{
		first1.Mismatch(last1, first2, pred, out first1, out first2);
		if (first1.IsEqual(last1))
		{
			return true;
		}
		ListIterator<T> it = first2;
		it = it.GetAdvanced(first1.Distance(last1));
		ListIterator<T> listIterator = first1;
		while (true)
		{
			if (listIterator.NotEqual(last1))
			{
				if (first1.Find(listIterator, listIterator.GetCurrent(), pred).IsEqual(listIterator))
				{
					int num = first2.Count(it, listIterator.GetCurrent(), pred);
					if (num == 0 || listIterator.Count(last1, listIterator.GetCurrent(), pred) != num)
					{
						break;
					}
				}
				listIterator = listIterator.GetNext();
				continue;
			}
			return true;
		}
		return false;
	}

	public static ListIterator<T> Search<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, Func<T, T, bool> pred)
	{
		if (first2.IsEqual(last2))
		{
			return first1;
		}
		while (first1.NotEqual(last1))
		{
			ListIterator<T> it = first1;
			ListIterator<T> it2 = first2;
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

	public static ListIterator<T> SearchN<T>(this ListIterator<T> first, ListIterator<T> last, int count, T val, Func<T, T, bool> pred)
	{
		ListIterator<T> advanced = first.GetAdvanced(first.Distance(last) - count);
		while (first.NotEqual(advanced))
		{
			ListIterator<T> it = first;
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

	public static ListIterator<T> Copy<T>(this ListIterator<T> first, ListIterator<T> last, ListIterator<T> result)
	{
		while (first.NotEqual(last))
		{
			result.SetCurrent(first.GetCurrent());
			result = result.GetNext();
			first = first.GetNext();
		}
		return result;
	}

	public static ListIterator<T> CopyN<T>(this ListIterator<T> first, int n, ListIterator<T> result)
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

	public static ListIterator<T> CopyIf<T>(this ListIterator<T> first, ListIterator<T> last, ListIterator<T> result, Func<T, bool> pred)
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

	public static ListIterator<T> CopyBackward<T>(this ListIterator<T> first, ListIterator<T> last, ListIterator<T> result)
	{
		while (last.NotEqual(first))
		{
			result = result.GetPrev();
			last = last.GetPrev();
			result.SetCurrent(last.GetCurrent());
		}
		return result;
	}

	public static ListIterator<T> SwapRanges<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2)
	{
		while (first1.NotEqual(last1))
		{
			first1.Swap(first2);
			first1 = first1.GetNext();
			first2 = first2.GetNext();
		}
		return first2;
	}

	public static void Swap<T>(this ListIterator<T> a, ListIterator<T> b)
	{
		T current = a.GetCurrent();
		a.SetCurrent(b.GetCurrent());
		b.SetCurrent(current);
	}

	public static ListIterator<T> Transform<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> result, Func<T, T> op)
	{
		while (first1.NotEqual(last1))
		{
			result.SetCurrent(op(first1.GetCurrent()));
			result = result.GetNext();
			first1 = first1.GetNext();
		}
		return result;
	}

	public static ListIterator<T> Transform<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> result, Func<T, T, T> binaryOp)
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

	public static void ReplaceIf<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred, T newValue)
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

	public static ListIterator<T> ReplaceCopyIf<T>(this ListIterator<T> first, ListIterator<T> last, ListIterator<T> result, Func<T, bool> pred, T newValue)
	{
		while (first.NotEqual(last))
		{
			result.SetCurrent(pred(first.GetCurrent()) ? newValue : first.GetCurrent());
			first = first.GetNext();
			result = result.GetNext();
		}
		return result;
	}

	public static ListIterator<T> Unique<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> pred)
	{
		if (first.IsEqual(last))
		{
			return last;
		}
		ListIterator<T> it = first;
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

	public static ListIterator<T> UniqueCopy<T>(this ListIterator<T> first, ListIterator<T> last, ListIterator<T> result, Func<T, T, bool> pred)
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

	public static void Reverse<T>(this ListIterator<T> first, ListIterator<T> last)
	{
		while (first.NotEqual(last) && first.NotEqual(last = last.GetPrev()))
		{
			first.Swap(last);
			first = first.GetNext();
		}
	}

	public static ListIterator<T> ReverseCopy<T>(this ListIterator<T> first, ListIterator<T> last, ListIterator<T> result)
	{
		while (first.NotEqual(last))
		{
			last = last.GetPrev();
			result.SetCurrent(last.GetCurrent());
			result = result.GetNext();
		}
		return result;
	}

	public static void Rotate<T>(this ListIterator<T> first, ListIterator<T> middle, ListIterator<T> last)
	{
		ListIterator<T> listIterator = middle;
		while (first.NotEqual(last))
		{
			first.Swap(listIterator);
			first = first.GetNext();
			listIterator = listIterator.GetNext();
			if (listIterator.IsEqual(last))
			{
				listIterator = middle;
			}
			else if (first.IsEqual(middle))
			{
				middle = listIterator;
			}
		}
	}

	public static ListIterator<T> RotateCopy<T>(this ListIterator<T> first, ListIterator<T> middle, ListIterator<T> last, ListIterator<T> result)
	{
		result = middle.Copy(last, result);
		return first.Copy(middle, result);
	}

	public static void RandomShuffle<T>(this ListIterator<T> first, ListIterator<T> last, Func<int, int> gen)
	{
		for (int num = first.Distance(last) - 1; num > 0; num--)
		{
			first.GetAdvanced(num).Swap(first.GetAdvanced(gen(num + 1)));
		}
	}

	public static bool IsPartitioned<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static ListIterator<T> Partition<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
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

	public static void PartitionCopy<T>(this ListIterator<T> first, ListIterator<T> last, ListIterator<T> resultTrue, ListIterator<T> resultFalse, Func<T, bool> pred, out ListIterator<T> outResultTrue, out ListIterator<T> outResultFalse)
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

	public static ListIterator<T> PartitionPoint<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, bool> pred)
	{
		int num = first.Distance(last);
		while (num > 0)
		{
			ListIterator<T> it = first;
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

	public static void Sort<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return;
		}
		ListIterator<T> listIterator = first;
		ListIterator<T> next = first.GetNext();
		while (next.NotEqual(last))
		{
			if (comp(next.GetCurrent(), first.GetCurrent()))
			{
				listIterator = listIterator.GetNext();
				listIterator.Swap(next);
			}
			next = next.GetNext();
		}
		first.Swap(listIterator);
		first.Sort(listIterator, comp);
		listIterator.GetNext().Sort(last, comp);
	}

	public static void StableSort<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		IList<T> list = first.List;
		for (int i = first.Index + 1; i < last.Index; i++)
		{
			T val = list[i];
			int num = first.Index;
			int num2 = i - 1;
			while (num <= num2)
			{
				int num3 = (num + num2) / 2;
				if (comp(val, list[num3]))
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
				list[num4 + 1] = list[num4];
			}
			list[num] = val;
		}
	}

	public static void PartialSort<T>(this ListIterator<T> first, ListIterator<T> middle, ListIterator<T> last, Func<T, T, bool> comp)
	{
		first.Sort(last, comp);
	}

	public static bool IsSorted<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return true;
		}
		ListIterator<T> it = first;
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

	public static ListIterator<T> IsSortedUntil<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return first;
		}
		ListIterator<T> listIterator = first;
		while (true)
		{
			if ((listIterator = listIterator.GetNext()).NotEqual(last))
			{
				if (comp(listIterator.GetCurrent(), first.GetCurrent()))
				{
					break;
				}
				first = first.GetNext();
				continue;
			}
			return last;
		}
		return listIterator;
	}

	public static void NthElement<T>(this ListIterator<T> first, ListIterator<T> nth, ListIterator<T> last, Func<T, T, bool> comp)
	{
		first.Sort(last, comp);
	}

	public static ListIterator<T> LowerBound<T>(this ListIterator<T> first, ListIterator<T> last, T val, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		while (num > 0)
		{
			ListIterator<T> it = first;
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

	public static ListIterator<T> UpperBound<T>(this ListIterator<T> first, ListIterator<T> last, T val, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		while (num > 0)
		{
			ListIterator<T> it = first;
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

	public static void EqualRange<T>(this ListIterator<T> first, ListIterator<T> last, T val, Func<T, T, bool> comp, out ListIterator<T> lower, out ListIterator<T> upper)
	{
		lower = first.LowerBound(last, val, comp);
		upper = lower.UpperBound(last, val, comp);
	}

	public static bool BinarySearch<T>(this ListIterator<T> first, ListIterator<T> last, T val, Func<T, T, bool> comp)
	{
		first = first.LowerBound(last, val, comp);
		if (first.NotEqual(last))
		{
			return !comp(val, first.GetCurrent());
		}
		return false;
	}

	public static ListIterator<T> Merge<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, ListIterator<T> result, Func<T, T, bool> comp)
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

	public static void InplaceMerge<T>(this ListIterator<T> first, ListIterator<T> middle, ListIterator<T> last, Func<T, T, bool> comp)
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
		ListIterator<T> listIterator;
		ListIterator<T> listIterator2;
		if (middle.Index - first.Index > last.Index - middle.Index)
		{
			listIterator = first.GetAdvanced(first.Distance(middle) / 2);
			listIterator2 = middle.LowerBound(last, listIterator.GetCurrent(), comp);
		}
		else
		{
			listIterator2 = middle.GetAdvanced(middle.Distance(last) / 2);
			listIterator = first.UpperBound(middle, listIterator2.GetCurrent(), comp);
		}
		listIterator.Rotate(middle, listIterator2);
		middle = listIterator.GetAdvanced(middle.Distance(listIterator2));
		first.InplaceMerge(listIterator, middle, comp);
		middle.InplaceMerge(listIterator2, last, comp);
	}

	public static bool Includes<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, Func<T, T, bool> comp)
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

	public static ListIterator<T> SetUnion<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, ListIterator<T> result, Func<T, T, bool> comp)
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

	public static ListIterator<T> SetIntersection<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, ListIterator<T> result, Func<T, T, bool> comp)
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

	public static ListIterator<T> SetDifference<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, ListIterator<T> result, Func<T, T, bool> comp)
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

	public static ListIterator<T> SetSymmetricDifference<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, ListIterator<T> result, Func<T, T, bool> comp)
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

	public static void PushHeap<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.Distance(last) >= 2)
		{
			last = last.GetPrev();
			T current = last.GetCurrent();
			ListIterator<T> advanced = first.GetAdvanced((first.Distance(last) - 1) / 2);
			while (first.Distance(last) > 0 && comp(advanced.GetCurrent(), current))
			{
				last.SetCurrent(advanced.GetCurrent());
				last = advanced;
				advanced = first.GetAdvanced((first.Distance(last) - 1) / 2);
			}
			last.SetCurrent(current);
		}
	}

	public static void PopHeap<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.Distance(last) >= 2)
		{
			last = last.GetPrev();
			first.Swap(last);
			first.List.smethod_0(first.Index, first.Index, last.Index, comp);
		}
	}

	public static void MakeHeap<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		if (num >= 2)
		{
			int num2 = (num - 2) / 2;
			do
			{
				first.List.smethod_0(first.Index, first.Index + num2, last.Index, comp);
			}
			while (num2-- != 0);
		}
	}

	public static void SortHeap<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		while (first.Distance(last) > 1)
		{
			last = last.GetPrev();
			first.Swap(last);
			first.List.smethod_0(first.Index, first.Index, last.Index, comp);
		}
	}

	private static void smethod_0<T>(this IList<T> ilist_0, int int_0, int int_1, int int_2, Func<T, T, bool> func_0)
	{
		T val = ilist_0[int_1];
		int num = int_2 - int_0;
		int num2 = int_1 - int_0;
		int num3;
		for (num3 = 2 * num2 + 2; num3 < num; num3 *= 2)
		{
			if (func_0(ilist_0[int_0 + num3], ilist_0[int_0 + (num3 - 1)]))
			{
				num3--;
			}
			ilist_0[int_0 + num2] = ilist_0[int_0 + num3];
			num2 = num3++;
		}
		if (num3-- == num)
		{
			ilist_0[int_0 + num2] = ilist_0[int_0 + num3];
			num2 = num3;
		}
		int num4 = (num2 - 1) / 2;
		int num5 = int_1 - int_0;
		while (num2 != num5 && func_0(ilist_0[int_0 + num4], val))
		{
			ilist_0[int_0 + num2] = ilist_0[int_0 + num4];
			num2 = num4;
			num4 = (num2 - 1) / 2;
		}
		ilist_0[int_0 + num2] = val;
	}

	public static bool IsHeap<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		return first.IsHeapUntil(last, comp).IsEqual(last);
	}

	public static ListIterator<T> IsHeapUntil<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		int num = first.Distance(last);
		int num2 = 0;
		int num3 = 1;
		ListIterator<T> it = first;
		ListIterator<T> advanced;
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

	public static ListIterator<T> MinElement<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return last;
		}
		ListIterator<T> listIterator = first;
		while ((first = first.GetNext()).NotEqual(last))
		{
			if (comp(first.GetCurrent(), listIterator.GetCurrent()))
			{
				listIterator = first;
			}
		}
		return listIterator;
	}

	public static ListIterator<T> MaxElement<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		if (first.IsEqual(last))
		{
			return last;
		}
		ListIterator<T> listIterator = first;
		while ((first = first.GetNext()).NotEqual(last))
		{
			if (comp(listIterator.GetCurrent(), first.GetCurrent()))
			{
				listIterator = first;
			}
		}
		return listIterator;
	}

	public static void MinMaxElement<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp, out ListIterator<T> min, out ListIterator<T> max)
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

	public static bool LexicographicalCompare<T>(this ListIterator<T> first1, ListIterator<T> last1, ListIterator<T> first2, ListIterator<T> last2, Func<T, T, bool> comp)
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

	public static bool NextPermutation<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		ListIterator<T> it = last;
		if (!first.IsEqual(last) && !first.IsEqual(it = it.GetPrev()))
		{
			do
			{
				ListIterator<T> listIterator = it;
				if (comp((it = it.GetPrev()).GetCurrent(), listIterator.GetCurrent()))
				{
					ListIterator<T> listIterator2 = last;
					while (!comp(it.GetCurrent(), (listIterator2 = listIterator2.GetPrev()).GetCurrent()))
					{
					}
					it.Swap(listIterator2);
					listIterator.Reverse(last);
					return true;
				}
			}
			while (!it.IsEqual(first));
			first.Reverse(last);
			return false;
		}
		return false;
	}

	public static bool PrevPermutation<T>(this ListIterator<T> first, ListIterator<T> last, Func<T, T, bool> comp)
	{
		ListIterator<T> it = last;
		if (!first.IsEqual(last) && !first.IsEqual(it = it.GetPrev()))
		{
			do
			{
				ListIterator<T> listIterator = it;
				if (comp(listIterator.GetCurrent(), (it = it.GetPrev()).GetCurrent()))
				{
					ListIterator<T> listIterator2 = last;
					while (!comp((listIterator2 = listIterator2.GetPrev()).GetCurrent(), it.GetCurrent()))
					{
					}
					it.Swap(listIterator2);
					listIterator.Reverse(last);
					return true;
				}
			}
			while (!it.IsEqual(first));
			first.Reverse(last);
			return false;
		}
		return false;
	}

	static ListIteratorExtensions()
	{
		Class72.smethod_20();
	}
}
