using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ServiceStack.Text;

namespace DiffMatchPatch;

public sealed class diff_match_patch
{
	public float Diff_Timeout = 1f;

	public short Diff_EditCost = 4;

	public float Match_Threshold = 0.5f;

	public int Match_Distance = 1000;

	public float Patch_DeleteThreshold = 0.5f;

	public short Patch_Margin = 4;

	private short short_0 = 32;

	private Regex regex_0 = new Regex("\\n\\r?\\n\\Z");

	private Regex regex_1 = new Regex("\\A\\r?\\n\\r?\\n");

	public List<Diff> diff_main(string text1, string text2)
	{
		return diff_main(text1, text2, checklines: true);
	}

	public List<Diff> diff_main(string text1, string text2, bool checklines)
	{
		DateTime dateTime_ = ((!(Diff_Timeout > 0f)) ? DateTime.MaxValue : (DateTime.Now + new TimeSpan((long)(Diff_Timeout * 1000f) * 10000L)));
		return method_0(text1, text2, checklines, dateTime_);
	}

	private List<Diff> method_0(string string_0, string string_1, bool bool_0, DateTime dateTime_0)
	{
		List<Diff> list;
		if (string_0 == string_1)
		{
			list = new List<Diff>();
			if (string_0.Length != 0)
			{
				list.Add(new Diff(Operation.EQUAL, string_0));
			}
			return list;
		}
		int num = diff_commonPrefix(string_0, string_1);
		string text = string_0.Substring(0, num);
		string_0 = string_0.Substring(num);
		string_1 = string_1.Substring(num);
		num = diff_commonSuffix(string_0, string_1);
		string text2 = string_0.Substring(string_0.Length - num);
		string_0 = string_0.Substring(0, string_0.Length - num);
		string_1 = string_1.Substring(0, string_1.Length - num);
		list = method_1(string_0, string_1, bool_0, dateTime_0);
		if (text.Length != 0)
		{
			list.Insert(0, new Diff(Operation.EQUAL, text));
		}
		if (text2.Length != 0)
		{
			list.Add(new Diff(Operation.EQUAL, text2));
		}
		diff_cleanupMerge(list);
		return list;
	}

	private List<Diff> method_1(string string_0, string string_1, bool bool_0, DateTime dateTime_0)
	{
		List<Diff> list = new List<Diff>();
		if (string_0.Length == 0)
		{
			list.Add(new Diff(Operation.INSERT, string_1));
			return list;
		}
		if (string_1.Length == 0)
		{
			list.Add(new Diff(Operation.DELETE, string_0));
			return list;
		}
		string text = ((string_0.Length <= string_1.Length) ? string_1 : string_0);
		string text2 = ((string_0.Length <= string_1.Length) ? string_0 : string_1);
		int num = text.IndexOf(text2, StringComparison.Ordinal);
		if (num != -1)
		{
			Operation operation = ((string_0.Length <= string_1.Length) ? Operation.INSERT : Operation.DELETE);
			list.Add(new Diff(operation, text.Substring(0, num)));
			list.Add(new Diff(Operation.EQUAL, text2));
			list.Add(new Diff(operation, text.Substring(num + text2.Length)));
			return list;
		}
		if (text2.Length == 1)
		{
			list.Add(new Diff(Operation.DELETE, string_0));
			list.Add(new Diff(Operation.INSERT, string_1));
			return list;
		}
		string[] array = diff_halfMatch(string_0, string_1);
		if (array != null)
		{
			string string_2 = array[0];
			string string_3 = array[1];
			string string_4 = array[2];
			string string_5 = array[3];
			string text3 = array[4];
			List<Diff> list2 = method_0(string_2, string_4, bool_0, dateTime_0);
			List<Diff> collection = method_0(string_3, string_5, bool_0, dateTime_0);
			list = list2;
			list.Add(new Diff(Operation.EQUAL, text3));
			list.AddRange(collection);
			return list;
		}
		if (bool_0 && string_0.Length > 100 && string_1.Length > 100)
		{
			return method_2(string_0, string_1, dateTime_0);
		}
		return diff_bisect(string_0, string_1, dateTime_0);
	}

	private List<Diff> method_2(string string_0, string string_1, DateTime dateTime_0)
	{
		object[] array = diff_linesToChars(string_0, string_1);
		string_0 = (string)array[0];
		string_1 = (string)array[1];
		List<string> lineArray = (List<string>)array[2];
		List<Diff> list = method_0(string_0, string_1, bool_0: false, dateTime_0);
		diff_charsToLines(list, lineArray);
		diff_cleanupSemantic(list);
		list.Add(new Diff(Operation.EQUAL, string.Empty));
		int i = 0;
		int num = 0;
		int num2 = 0;
		string text = string.Empty;
		string text2 = string.Empty;
		for (; i < list.Count; i++)
		{
			switch (list[i].operation)
			{
			case Operation.DELETE:
				num++;
				text += list[i].text;
				break;
			case Operation.INSERT:
				num2++;
				text2 += list[i].text;
				break;
			case Operation.EQUAL:
			{
				int num3;
				if (num >= 1)
				{
					if (num2 < 1)
					{
						num3 = 0;
					}
					else
					{
						list.RemoveRange(i - num - num2, num + num2);
						i = i - num - num2;
						List<Diff> list2 = method_0(text, text2, bool_0: false, dateTime_0);
						list.InsertRange(i, list2);
						i += list2.Count;
						num3 = 0;
					}
				}
				else
				{
					num3 = 0;
				}
				num2 = num3;
				num = 0;
				text = string.Empty;
				text2 = string.Empty;
				break;
			}
			}
		}
		list.RemoveAt(list.Count - 1);
		return list;
	}

	protected List<Diff> diff_bisect(string text1, string text2, DateTime deadline)
	{
		int length = text1.Length;
		int length2 = text2.Length;
		int num = (length + length2 + 1) / 2;
		int num2 = num;
		int num3 = 2 * num;
		int[] array = new int[num3];
		int[] array2 = new int[num3];
		for (int i = 0; i < num3; i++)
		{
			array[i] = -1;
			array2[i] = -1;
		}
		array[num2 + 1] = 0;
		array2[num2 + 1] = 0;
		int num4 = length - length2;
		bool flag = num4 % 2 != 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		for (int j = 0; j < num; j++)
		{
			if (DateTime.Now > deadline)
			{
				break;
			}
			for (int k = -j + num5; k <= j - num6; k += 2)
			{
				int num9 = num2 + k;
				int num10 = ((k == -j || (k != j && array[num9 - 1] < array[num9 + 1])) ? array[num9 + 1] : (array[num9 - 1] + 1));
				int num11 = num10 - k;
				while (num10 < length && num11 < length2 && text1[num10] == text2[num11])
				{
					num10++;
					num11++;
				}
				array[num9] = num10;
				if (num10 <= length)
				{
					if (num11 <= length2)
					{
						if (!flag)
						{
							continue;
						}
						int num12 = num2 + num4 - k;
						if (num12 >= 0 && num12 < num3 && array2[num12] != -1)
						{
							int num13 = length - array2[num12];
							if (num10 >= num13)
							{
								return method_3(text1, text2, num10, num11, deadline);
							}
						}
					}
					else
					{
						num5 += 2;
					}
				}
				else
				{
					num6 += 2;
				}
			}
			for (int l = -j + num7; l <= j - num8; l += 2)
			{
				int num14 = num2 + l;
				int num15 = ((l == -j || (l != j && array2[num14 - 1] < array2[num14 + 1])) ? array2[num14 + 1] : (array2[num14 - 1] + 1));
				int num16 = num15 - l;
				while (num15 < length && num16 < length2 && text1[length - num15 - 1] == text2[length2 - num16 - 1])
				{
					num15++;
					num16++;
				}
				array2[num14] = num15;
				if (num15 > length)
				{
					num8 += 2;
				}
				else if (num16 > length2)
				{
					num7 += 2;
				}
				else
				{
					if (flag)
					{
						continue;
					}
					int num17 = num2 + num4 - l;
					if (num17 >= 0 && num17 < num3 && array[num17] != -1)
					{
						int num18 = array[num17];
						int int_ = num2 + num18 - num17;
						num15 = length - array2[num14];
						if (num18 >= num15)
						{
							return method_3(text1, text2, num18, int_, deadline);
						}
					}
				}
			}
		}
		return new List<Diff>
		{
			new Diff(Operation.DELETE, text1),
			new Diff(Operation.INSERT, text2)
		};
	}

	private List<Diff> method_3(string string_0, string string_1, int int_0, int int_1, DateTime dateTime_0)
	{
		string string_2 = string_0.Substring(0, int_0);
		string string_3 = string_1.Substring(0, int_1);
		string string_4 = string_0.Substring(int_0);
		string string_5 = string_1.Substring(int_1);
		List<Diff> list = method_0(string_2, string_3, bool_0: false, dateTime_0);
		List<Diff> collection = method_0(string_4, string_5, bool_0: false, dateTime_0);
		list.AddRange(collection);
		return list;
	}

	protected object[] diff_linesToChars(string text1, string text2)
	{
		List<string> list = new List<string>();
		Dictionary<string, int> dictionary_ = new Dictionary<string, int>();
		list.Add(string.Empty);
		string text3 = method_4(text1, list, dictionary_, 40000);
		string text4 = method_4(text2, list, dictionary_, 65535);
		return new object[3] { text3, text4, list };
	}

	private string method_4(string string_0, List<string> list_0, Dictionary<string, int> dictionary_0, int int_0)
	{
		int num = 0;
		int num2 = -1;
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		while (num2 < string_0.Length - 1)
		{
			num2 = string_0.IndexOf('\n', num);
			if (num2 == -1)
			{
				num2 = string_0.Length - 1;
			}
			string text = CompatibilityExtensions.JavaSubstring(string_0, num, num2 + 1);
			if (dictionary_0.ContainsKey(text))
			{
				stringBuilder.Append((char)dictionary_0[text]);
			}
			else
			{
				if (list_0.Count == int_0)
				{
					text = string_0.Substring(num);
					num2 = string_0.Length;
				}
				list_0.Add(text);
				dictionary_0.Add(text, list_0.Count - 1);
				stringBuilder.Append((char)(list_0.Count - 1));
			}
			num = num2 + 1;
		}
		string result = stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return result;
	}

	protected void diff_charsToLines(ICollection<Diff> diffs, IList<string> lineArray)
	{
		foreach (Diff diff in diffs)
		{
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			for (int i = 0; i < diff.text.Length; i++)
			{
				stringBuilder.Append(lineArray[diff.text[i]]);
			}
			diff.text = stringBuilder.ToString();
			StringBuilderCache.Free(stringBuilder);
		}
	}

	public int diff_commonPrefix(string text1, string text2)
	{
		int num = Math.Min(text1.Length, text2.Length);
		for (int i = 0; i < num; i++)
		{
			if (text1[i] != text2[i])
			{
				return i;
			}
		}
		return num;
	}

	public int diff_commonSuffix(string text1, string text2)
	{
		int length = text1.Length;
		int length2 = text2.Length;
		int num = Math.Min(text1.Length, text2.Length);
		for (int i = 1; i <= num; i++)
		{
			if (text1[length - i] != text2[length2 - i])
			{
				return i - 1;
			}
		}
		return num;
	}

	protected int diff_commonOverlap(string text1, string text2)
	{
		int length = text1.Length;
		int length2 = text2.Length;
		int result2;
		if (length != 0)
		{
			if (length2 != 0)
			{
				if (length <= length2)
				{
					if (length < length2)
					{
						text2 = text2.Substring(0, length);
					}
				}
				else
				{
					text1 = text1.Substring(length - length2);
				}
				int num = Math.Min(length, length2);
				if (!(text1 == text2))
				{
					int result = 0;
					int num2 = 1;
					while (true)
					{
						string value = text1.Substring(num - num2);
						int num3 = text2.IndexOf(value, StringComparison.Ordinal);
						if (num3 == -1)
						{
							break;
						}
						num2 += num3;
						if (num3 == 0 || text1.Substring(num - num2) == text2.Substring(0, num2))
						{
							result = num2;
							num2++;
						}
					}
					return result;
				}
				return num;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return result2;
	}

	protected string[] diff_halfMatch(string text1, string text2)
	{
		if (Diff_Timeout > 0f)
		{
			string text3 = ((text1.Length > text2.Length) ? text1 : text2);
			string text4 = ((text1.Length <= text2.Length) ? text1 : text2);
			if (text3.Length >= 4 && text4.Length * 2 >= text3.Length)
			{
				string[] array = method_5(text3, text4, (text3.Length + 3) / 4);
				string[] array2 = method_5(text3, text4, (text3.Length + 1) / 2);
				if (array == null && array2 == null)
				{
					return null;
				}
				string[] array3 = ((array2 == null) ? array : ((array != null) ? ((array[4].Length > array2[4].Length) ? array : array2) : array2));
				if (text1.Length > text2.Length)
				{
					return array3;
				}
				return new string[5]
				{
					array3[2],
					array3[3],
					array3[0],
					array3[1],
					array3[4]
				};
			}
			return null;
		}
		return null;
	}

	private string[] method_5(string string_0, string string_1, int int_0)
	{
		string value = string_0.Substring(int_0, string_0.Length / 4);
		int num = -1;
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string text4 = string.Empty;
		string text5 = string.Empty;
		while (num < string_1.Length && (num = string_1.IndexOf(value, num + 1, StringComparison.Ordinal)) != -1)
		{
			int num2 = diff_commonPrefix(string_0.Substring(int_0), string_1.Substring(num));
			int num3 = diff_commonSuffix(string_0.Substring(0, int_0), string_1.Substring(0, num));
			if (text.Length < num3 + num2)
			{
				text = string_1.Substring(num - num3, num3) + string_1.Substring(num, num2);
				text2 = string_0.Substring(0, int_0 - num3);
				text3 = string_0.Substring(int_0 + num2);
				text4 = string_1.Substring(0, num - num3);
				text5 = string_1.Substring(num + num2);
			}
		}
		if (text.Length * 2 >= string_0.Length)
		{
			return new string[5] { text2, text3, text4, text5, text };
		}
		return null;
	}

	public void diff_cleanupSemantic(List<Diff> diffs)
	{
		bool flag = false;
		Stack<int> stack = new Stack<int>();
		string text = null;
		int i = 0;
		int val = 0;
		int val2 = 0;
		int num = 0;
		int num2 = 0;
		for (; i < diffs.Count; i++)
		{
			if (diffs[i].operation == Operation.EQUAL)
			{
				stack.Push(i);
				val = num;
				val2 = num2;
				num = 0;
				num2 = 0;
				text = diffs[i].text;
				continue;
			}
			if (diffs[i].operation == Operation.INSERT)
			{
				num += diffs[i].text.Length;
			}
			else
			{
				num2 += diffs[i].text.Length;
			}
			if (text != null && text.Length <= Math.Max(val, val2) && text.Length <= Math.Max(num, num2))
			{
				diffs.Insert(stack.Peek(), new Diff(Operation.DELETE, text));
				diffs[stack.Peek() + 1].operation = Operation.INSERT;
				stack.Pop();
				if (stack.Count > 0)
				{
					stack.Pop();
				}
				i = ((stack.Count > 0) ? stack.Peek() : (-1));
				val = 0;
				val2 = 0;
				num = 0;
				num2 = 0;
				text = null;
				flag = true;
			}
		}
		if (flag)
		{
			diff_cleanupMerge(diffs);
		}
		diff_cleanupSemanticLossless(diffs);
		for (i = 1; i < diffs.Count; i++)
		{
			if (diffs[i - 1].operation != Operation.DELETE || diffs[i].operation != Operation.INSERT)
			{
				continue;
			}
			string text2 = diffs[i - 1].text;
			string text3 = diffs[i].text;
			int num3 = diff_commonOverlap(text2, text3);
			int num4 = diff_commonOverlap(text3, text2);
			if (num3 >= num4)
			{
				if ((double)num3 >= (double)text2.Length / 2.0 || (double)num3 >= (double)text3.Length / 2.0)
				{
					diffs.Insert(i, new Diff(Operation.EQUAL, text3.Substring(0, num3)));
					diffs[i - 1].text = text2.Substring(0, text2.Length - num3);
					diffs[i + 1].text = text3.Substring(num3);
					i++;
				}
			}
			else if ((double)num4 >= (double)text2.Length / 2.0 || (double)num4 >= (double)text3.Length / 2.0)
			{
				diffs.Insert(i, new Diff(Operation.EQUAL, text2.Substring(0, num4)));
				diffs[i - 1].operation = Operation.INSERT;
				diffs[i - 1].text = text3.Substring(0, text3.Length - num4);
				diffs[i + 1].operation = Operation.DELETE;
				diffs[i + 1].text = text2.Substring(num4);
				i++;
			}
			i++;
		}
	}

	public void diff_cleanupSemanticLossless(List<Diff> diffs)
	{
		for (int i = 1; i < diffs.Count - 1; i++)
		{
			if (diffs[i - 1].operation != Operation.EQUAL || diffs[i + 1].operation != Operation.EQUAL)
			{
				continue;
			}
			string text = diffs[i - 1].text;
			string text2 = diffs[i].text;
			string text3 = diffs[i + 1].text;
			int num = diff_commonSuffix(text, text2);
			if (num > 0)
			{
				string text4 = text2.Substring(text2.Length - num);
				text = text.Substring(0, text.Length - num);
				text2 = text4 + text2.Substring(0, text2.Length - num);
				text3 = text4 + text3;
			}
			string text5 = text;
			string text6 = text2;
			string text7 = text3;
			int num2 = method_6(text, text2) + method_6(text2, text3);
			while (text2.Length != 0 && text3.Length != 0 && text2[0] == text3[0])
			{
				text += text2[0];
				text2 = text2.Substring(1) + text3[0];
				text3 = text3.Substring(1);
				int num3 = method_6(text, text2) + method_6(text2, text3);
				if (num3 >= num2)
				{
					num2 = num3;
					text5 = text;
					text6 = text2;
					text7 = text3;
				}
			}
			if (diffs[i - 1].text != text5)
			{
				if (text5.Length == 0)
				{
					diffs.RemoveAt(i - 1);
					i--;
				}
				else
				{
					diffs[i - 1].text = text5;
				}
				diffs[i].text = text6;
				if (text7.Length != 0)
				{
					diffs[i + 1].text = text7;
					continue;
				}
				diffs.RemoveAt(i + 1);
				i--;
			}
		}
	}

	private int method_6(string string_0, string string_1)
	{
		if (string_0.Length != 0 && string_1.Length != 0)
		{
			char c = string_0[string_0.Length - 1];
			char c2 = string_1[0];
			bool flag = !char.IsLetterOrDigit(c);
			bool flag2 = !char.IsLetterOrDigit(c2);
			bool flag3 = flag && char.IsWhiteSpace(c);
			bool flag4 = flag2 && char.IsWhiteSpace(c2);
			bool flag5 = flag3 && char.IsControl(c);
			bool flag6 = flag4 && char.IsControl(c2);
			if (!((flag5 && regex_0.IsMatch(string_0)) | (flag6 && regex_1.IsMatch(string_1))))
			{
				if (!(flag5 || flag6))
				{
					if (!(flag && !flag3 && flag4))
					{
						if (flag3 || flag4)
						{
							return 2;
						}
						if (!(flag || flag2))
						{
							return 0;
						}
						return 1;
					}
					return 3;
				}
				return 4;
			}
			return 5;
		}
		return 6;
	}

	public void diff_cleanupEfficiency(List<Diff> diffs)
	{
		bool flag = false;
		Stack<int> stack = new Stack<int>();
		string text = string.Empty;
		int i = 0;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		for (; i < diffs.Count; i++)
		{
			if (diffs[i].operation == Operation.EQUAL)
			{
				int num;
				int num2;
				if (diffs[i].text.Length < Diff_EditCost && (flag4 || flag5))
				{
					stack.Push(i);
					flag2 = flag4;
					flag3 = flag5;
					text = diffs[i].text;
					num = 0;
					num2 = 0;
				}
				else
				{
					stack.Clear();
					text = string.Empty;
					num = 0;
					num2 = 0;
				}
				flag5 = (byte)num2 != 0;
				flag4 = (byte)num != 0;
				continue;
			}
			if (diffs[i].operation == Operation.DELETE)
			{
				flag5 = true;
			}
			else
			{
				flag4 = true;
			}
			if (text.Length == 0 || (!(flag2 && flag3 && flag4 && flag5) && (text.Length >= Diff_EditCost / 2 || (flag2 ? 1 : 0) + (flag3 ? 1 : 0) + (flag4 ? 1 : 0) + (flag5 ? 1 : 0) != 3)))
			{
				continue;
			}
			diffs.Insert(stack.Peek(), new Diff(Operation.DELETE, text));
			diffs[stack.Peek() + 1].operation = Operation.INSERT;
			stack.Pop();
			text = string.Empty;
			int num3;
			if (flag2 && flag3)
			{
				flag5 = true;
				flag4 = true;
				stack.Clear();
				num3 = 1;
			}
			else
			{
				if (stack.Count > 0)
				{
					stack.Pop();
				}
				i = ((stack.Count <= 0) ? (-1) : stack.Peek());
				flag5 = false;
				flag4 = false;
				num3 = 1;
			}
			flag = (byte)num3 != 0;
		}
		if (flag)
		{
			diff_cleanupMerge(diffs);
		}
	}

	public void diff_cleanupMerge(List<Diff> diffs)
	{
		diffs.Add(new Diff(Operation.EQUAL, string.Empty));
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string text = string.Empty;
		string text2 = string.Empty;
		while (num < diffs.Count)
		{
			switch (diffs[num].operation)
			{
			case Operation.DELETE:
				num2++;
				text += diffs[num].text;
				num++;
				break;
			case Operation.INSERT:
				num3++;
				text2 += diffs[num].text;
				num++;
				break;
			case Operation.EQUAL:
			{
				int num5;
				if (num2 + num3 > 1)
				{
					if (num2 != 0 && num3 != 0)
					{
						int num4 = diff_commonPrefix(text2, text);
						if (num4 != 0)
						{
							if (num - num2 - num3 > 0 && diffs[num - num2 - num3 - 1].operation == Operation.EQUAL)
							{
								diffs[num - num2 - num3 - 1].text += text2.Substring(0, num4);
							}
							else
							{
								diffs.Insert(0, new Diff(Operation.EQUAL, text2.Substring(0, num4)));
								num++;
							}
							text2 = text2.Substring(num4);
							text = text.Substring(num4);
						}
						num4 = diff_commonSuffix(text2, text);
						if (num4 != 0)
						{
							diffs[num].text = text2.Substring(text2.Length - num4) + diffs[num].text;
							text2 = text2.Substring(0, text2.Length - num4);
							text = text.Substring(0, text.Length - num4);
						}
					}
					num -= num2 + num3;
					CompatibilityExtensions.Splice(diffs, num, num2 + num3);
					if (text.Length != 0)
					{
						CompatibilityExtensions.Splice(diffs, num, 0, new Diff(Operation.DELETE, text));
						num++;
					}
					if (text2.Length != 0)
					{
						CompatibilityExtensions.Splice(diffs, num, 0, new Diff(Operation.INSERT, text2));
						num++;
					}
					num++;
					num5 = 0;
				}
				else if (num != 0 && diffs[num - 1].operation == Operation.EQUAL)
				{
					diffs[num - 1].text += diffs[num].text;
					diffs.RemoveAt(num);
					num5 = 0;
				}
				else
				{
					num++;
					num5 = 0;
				}
				num3 = num5;
				num2 = 0;
				text = string.Empty;
				text2 = string.Empty;
				break;
			}
			}
		}
		int num6;
		if (diffs[diffs.Count - 1].text.Length != 0)
		{
			num6 = 0;
		}
		else
		{
			diffs.RemoveAt(diffs.Count - 1);
			num6 = 0;
		}
		bool flag = (byte)num6 != 0;
		for (num = 1; num < diffs.Count - 1; num++)
		{
			if (diffs[num - 1].operation == Operation.EQUAL && diffs[num + 1].operation == Operation.EQUAL)
			{
				if (diffs[num].text.EndsWith(diffs[num - 1].text, StringComparison.Ordinal))
				{
					diffs[num].text = diffs[num - 1].text + diffs[num].text.Substring(0, diffs[num].text.Length - diffs[num - 1].text.Length);
					diffs[num + 1].text = diffs[num - 1].text + diffs[num + 1].text;
					CompatibilityExtensions.Splice(diffs, num - 1, 1);
					flag = true;
				}
				else if (diffs[num].text.StartsWith(diffs[num + 1].text, StringComparison.Ordinal))
				{
					diffs[num - 1].text += diffs[num + 1].text;
					diffs[num].text = diffs[num].text.Substring(diffs[num + 1].text.Length) + diffs[num + 1].text;
					CompatibilityExtensions.Splice(diffs, num + 1, 1);
					flag = true;
				}
			}
		}
		if (flag)
		{
			diff_cleanupMerge(diffs);
		}
	}

	public int diff_xIndex(List<Diff> diffs, int loc)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Diff diff = null;
		foreach (Diff diff2 in diffs)
		{
			if (diff2.operation != Operation.INSERT)
			{
				num += diff2.text.Length;
			}
			if (diff2.operation != Operation.DELETE)
			{
				num2 += diff2.text.Length;
			}
			if (num <= loc)
			{
				num3 = num;
				num4 = num2;
				continue;
			}
			diff = diff2;
			break;
		}
		if (diff != null && diff.operation == Operation.DELETE)
		{
			return num4;
		}
		return num4 + (loc - num3);
	}

	public string diff_prettyHtml(List<Diff> diffs)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		foreach (Diff diff in diffs)
		{
			string value = diff.text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")
				.Replace("\n", "&para;<br>");
			switch (diff.operation)
			{
			case Operation.DELETE:
				stringBuilder.Append("<del style=\"background:#ffe6e6;\">").Append(value).Append("</del>");
				break;
			case Operation.INSERT:
				stringBuilder.Append("<ins style=\"background:#e6ffe6;\">").Append(value).Append("</ins>");
				break;
			case Operation.EQUAL:
				stringBuilder.Append("<span>").Append(value).Append("</span>");
				break;
			}
		}
		string result = stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return result;
	}

	public string diff_text1(List<Diff> diffs)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		foreach (Diff diff in diffs)
		{
			if (diff.operation != Operation.INSERT)
			{
				stringBuilder.Append(diff.text);
			}
		}
		string result = stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return result;
	}

	public string diff_text2(List<Diff> diffs)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		foreach (Diff diff in diffs)
		{
			if (diff.operation != Operation.DELETE)
			{
				stringBuilder.Append(diff.text);
			}
		}
		string result = stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return result;
	}

	public int diff_levenshtein(List<Diff> diffs)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (Diff diff in diffs)
		{
			switch (diff.operation)
			{
			case Operation.DELETE:
				num3 += diff.text.Length;
				break;
			case Operation.INSERT:
				num2 += diff.text.Length;
				break;
			case Operation.EQUAL:
				num += Math.Max(num2, num3);
				num2 = 0;
				num3 = 0;
				break;
			}
		}
		return num + Math.Max(num2, num3);
	}

	public string diff_toDelta(List<Diff> diffs)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		foreach (Diff diff in diffs)
		{
			switch (diff.operation)
			{
			case Operation.DELETE:
				stringBuilder.Append("-").Append(diff.text.Length).Append("\t");
				break;
			case Operation.INSERT:
				stringBuilder.Append("+").Append(smethod_0(diff.text)).Append("\t");
				break;
			case Operation.EQUAL:
				stringBuilder.Append("=").Append(diff.text.Length).Append("\t");
				break;
			}
		}
		string text = stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		if (text.Length != 0)
		{
			text = text.Substring(0, text.Length - 1);
		}
		return text;
	}

	public List<Diff> diff_fromDelta(string text1, string delta)
	{
		List<Diff> list = new List<Diff>();
		int num = 0;
		string[] array = delta.Split(new string[1] { "\t" }, StringSplitOptions.None);
		foreach (string text2 in array)
		{
			if (text2.Length == 0)
			{
				continue;
			}
			string text3 = text2.Substring(1);
			switch (text2[0])
			{
			case '-':
			case '=':
			{
				int num2;
				try
				{
					num2 = Convert.ToInt32(text3);
				}
				catch (FormatException innerException)
				{
					throw new ArgumentException("Invalid number in diff_fromDelta: " + text3, innerException);
				}
				if (num2 >= 0)
				{
					string text4;
					try
					{
						text4 = text1.Substring(num, num2);
						num += num2;
					}
					catch (ArgumentOutOfRangeException innerException2)
					{
						throw new ArgumentException("Delta length (" + num + ") larger than source text length (" + text1.Length + ").", innerException2);
					}
					if (text2[0] == '=')
					{
						list.Add(new Diff(Operation.EQUAL, text4));
					}
					else
					{
						list.Add(new Diff(Operation.DELETE, text4));
					}
					break;
				}
				throw new ArgumentException("Negative number in diff_fromDelta: " + text3);
			}
			case '+':
				text3 = text3.Replace("+", "%2b");
				text3 = HttpUtility.UrlDecode(text3);
				list.Add(new Diff(Operation.INSERT, text3));
				break;
			default:
				throw new ArgumentException("Invalid diff operation in diff_fromDelta: " + text2[0]);
			}
		}
		if (num != text1.Length)
		{
			throw new ArgumentException("Delta length (" + num + ") smaller than source text length (" + text1.Length + ").");
		}
		return list;
	}

	public int match_main(string text, string pattern, int loc)
	{
		loc = Math.Max(0, Math.Min(loc, text.Length));
		if (!(text == pattern))
		{
			if (text.Length != 0)
			{
				if (loc + pattern.Length <= text.Length && text.Substring(loc, pattern.Length) == pattern)
				{
					return loc;
				}
				return match_bitap(text, pattern, loc);
			}
			return -1;
		}
		return 0;
	}

	protected int match_bitap(string text, string pattern, int loc)
	{
		Dictionary<char, int> dictionary = match_alphabet(pattern);
		double num = Match_Threshold;
		int num2 = text.IndexOf(pattern, loc, StringComparison.Ordinal);
		int num3;
		if (num2 != -1)
		{
			num = Math.Min(method_7(0, num2, loc, pattern), num);
			num2 = text.LastIndexOf(pattern, Math.Min(loc + pattern.Length, text.Length), StringComparison.Ordinal);
			if (num2 != -1)
			{
				num = Math.Min(method_7(0, num2, loc, pattern), num);
				num3 = 1;
				goto IL_0064;
			}
		}
		num3 = 1;
		goto IL_0064;
		IL_0064:
		int num4 = num3 << pattern.Length - 1;
		num2 = -1;
		int num5 = pattern.Length + text.Length;
		int[] array = new int[0];
		for (int i = 0; i < pattern.Length; i++)
		{
			int num6 = 0;
			int num7 = num5;
			while (num6 < num7)
			{
				if (method_7(i, loc + num7, loc, pattern) <= num)
				{
					num6 = num7;
				}
				else
				{
					num5 = num7;
				}
				num7 = (num5 - num6) / 2 + num6;
			}
			num5 = num7;
			int num8 = Math.Max(1, loc - num7 + 1);
			int num9 = Math.Min(loc + num7, text.Length) + pattern.Length;
			int[] array2 = new int[num9 + 2];
			array2[num9 + 1] = (1 << i) - 1;
			for (int num10 = num9; num10 >= num8; num10--)
			{
				int num11 = ((text.Length > num10 - 1 && dictionary.ContainsKey(text[num10 - 1])) ? dictionary[text[num10 - 1]] : 0);
				if (i == 0)
				{
					array2[num10] = ((array2[num10 + 1] << 1) | 1) & num11;
				}
				else
				{
					array2[num10] = (((array2[num10 + 1] << 1) | 1) & num11) | (((array[num10 + 1] | array[num10]) << 1) | 1) | array[num10 + 1];
				}
				if ((array2[num10] & num4) != 0)
				{
					double num12 = method_7(i, num10 - 1, loc, pattern);
					if (num12 <= num)
					{
						num = num12;
						num2 = num10 - 1;
						if (num2 <= loc)
						{
							break;
						}
						num8 = Math.Max(1, 2 * loc - num2);
					}
				}
			}
			if (method_7(i + 1, loc, loc, pattern) > num)
			{
				break;
			}
			array = array2;
		}
		return num2;
	}

	private double method_7(int int_0, int int_1, int int_2, string string_0)
	{
		float num = (float)int_0 / (float)string_0.Length;
		int num2 = Math.Abs(int_2 - int_1);
		if (Match_Distance == 0)
		{
			if (num2 == 0)
			{
				return num;
			}
			return 1.0;
		}
		return num + (float)num2 / (float)Match_Distance;
	}

	protected Dictionary<char, int> match_alphabet(string pattern)
	{
		Dictionary<char, int> dictionary = new Dictionary<char, int>();
		char[] array = pattern.ToCharArray();
		char[] array2 = array;
		foreach (char key in array2)
		{
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, 0);
			}
		}
		int num = 0;
		array2 = array;
		foreach (char key2 in array2)
		{
			int value = dictionary[key2] | (1 << pattern.Length - num - 1);
			dictionary[key2] = value;
			num++;
		}
		return dictionary;
	}

	protected void patch_addContext(Patch patch, string text)
	{
		if (text.Length != 0)
		{
			string text2 = text.Substring(patch.start2, patch.length1);
			int num = 0;
			while (text.IndexOf(text2, StringComparison.Ordinal) != text.LastIndexOf(text2, StringComparison.Ordinal) && text2.Length < short_0 - Patch_Margin - Patch_Margin)
			{
				num += Patch_Margin;
				text2 = CompatibilityExtensions.JavaSubstring(text, Math.Max(0, patch.start2 - num), Math.Min(text.Length, patch.start2 + patch.length1 + num));
			}
			num += Patch_Margin;
			string text3 = CompatibilityExtensions.JavaSubstring(text, Math.Max(0, patch.start2 - num), patch.start2);
			if (text3.Length != 0)
			{
				patch.diffs.Insert(0, new Diff(Operation.EQUAL, text3));
			}
			string text4 = CompatibilityExtensions.JavaSubstring(text, patch.start2 + patch.length1, Math.Min(text.Length, patch.start2 + patch.length1 + num));
			if (text4.Length != 0)
			{
				patch.diffs.Add(new Diff(Operation.EQUAL, text4));
			}
			patch.start1 -= text3.Length;
			patch.start2 -= text3.Length;
			patch.length1 += text3.Length + text4.Length;
			patch.length2 += text3.Length + text4.Length;
		}
	}

	public List<Patch> patch_make(string text1, string text2)
	{
		List<Diff> list = diff_main(text1, text2, checklines: true);
		if (list.Count > 2)
		{
			diff_cleanupSemantic(list);
			diff_cleanupEfficiency(list);
		}
		return patch_make(text1, list);
	}

	public List<Patch> patch_make(List<Diff> diffs)
	{
		string text = diff_text1(diffs);
		return patch_make(text, diffs);
	}

	public List<Patch> patch_make(string text1, string text2, List<Diff> diffs)
	{
		return patch_make(text1, diffs);
	}

	public List<Patch> patch_make(string text1, List<Diff> diffs)
	{
		List<Patch> list = new List<Patch>();
		if (diffs.Count == 0)
		{
			return list;
		}
		Patch patch = new Patch();
		int num = 0;
		int num2 = 0;
		string text2 = text1;
		string text3 = text1;
		foreach (Diff diff in diffs)
		{
			if (patch.diffs.Count == 0 && diff.operation != Operation.EQUAL)
			{
				patch.start1 = num;
				patch.start2 = num2;
			}
			switch (diff.operation)
			{
			case Operation.DELETE:
				patch.length1 += diff.text.Length;
				patch.diffs.Add(diff);
				text3 = text3.Remove(num2, diff.text.Length);
				break;
			case Operation.INSERT:
				patch.diffs.Add(diff);
				patch.length2 += diff.text.Length;
				text3 = text3.Insert(num2, diff.text);
				break;
			case Operation.EQUAL:
				if (diff.text.Length <= 2 * Patch_Margin && patch.diffs.Count() != 0 && diff != diffs.Last())
				{
					patch.diffs.Add(diff);
					patch.length1 += diff.text.Length;
					patch.length2 += diff.text.Length;
				}
				if (diff.text.Length >= 2 * Patch_Margin && patch.diffs.Count != 0)
				{
					patch_addContext(patch, text2);
					list.Add(patch);
					patch = new Patch();
					text2 = text3;
					num = num2;
				}
				break;
			}
			if (diff.operation != Operation.INSERT)
			{
				num += diff.text.Length;
			}
			if (diff.operation != Operation.DELETE)
			{
				num2 += diff.text.Length;
			}
		}
		if (patch.diffs.Count != 0)
		{
			patch_addContext(patch, text2);
			list.Add(patch);
		}
		return list;
	}

	public List<Patch> patch_deepCopy(List<Patch> patches)
	{
		List<Patch> list = new List<Patch>();
		foreach (Patch patch2 in patches)
		{
			Patch patch = new Patch();
			foreach (Diff diff in patch2.diffs)
			{
				Diff item = new Diff(diff.operation, diff.text);
				patch.diffs.Add(item);
			}
			patch.start1 = patch2.start1;
			patch.start2 = patch2.start2;
			patch.length1 = patch2.length1;
			patch.length2 = patch2.length2;
			list.Add(patch);
		}
		return list;
	}

	public object[] patch_apply(List<Patch> patches, string text)
	{
		if (patches.Count != 0)
		{
			patches = patch_deepCopy(patches);
			string text2 = patch_addPadding(patches);
			text = text2 + text + text2;
			patch_splitMax(patches);
			int num = 0;
			int num2 = 0;
			bool[] array = new bool[patches.Count];
			foreach (Patch patch in patches)
			{
				int num3 = patch.start2 + num2;
				string text3 = diff_text1(patch.diffs);
				int num4 = -1;
				int num5;
				if (text3.Length > short_0)
				{
					num5 = match_main(text, text3.Substring(0, short_0), num3);
					if (num5 != -1)
					{
						num4 = match_main(text, text3.Substring(text3.Length - short_0), num3 + text3.Length - short_0);
						int num6;
						if (num4 != -1)
						{
							if (num5 < num4)
							{
								goto IL_00ff;
							}
							num6 = -1;
						}
						else
						{
							num6 = -1;
						}
						num5 = num6;
					}
				}
				else
				{
					num5 = match_main(text, text3, num3);
				}
				goto IL_00ff;
				IL_00ff:
				if (num5 == -1)
				{
					array[num] = false;
					num2 -= patch.length2 - patch.length1;
				}
				else
				{
					array[num] = true;
					num2 = num5 - num3;
					string text4 = ((num4 != -1) ? CompatibilityExtensions.JavaSubstring(text, num5, Math.Min(num4 + short_0, text.Length)) : CompatibilityExtensions.JavaSubstring(text, num5, Math.Min(num5 + text3.Length, text.Length)));
					if (!(text3 == text4))
					{
						List<Diff> diffs = diff_main(text3, text4, checklines: false);
						if (text3.Length > short_0 && (float)diff_levenshtein(diffs) / (float)text3.Length > Patch_DeleteThreshold)
						{
							array[num] = false;
						}
						else
						{
							diff_cleanupSemanticLossless(diffs);
							int num7 = 0;
							foreach (Diff diff in patch.diffs)
							{
								if (diff.operation != Operation.EQUAL)
								{
									int num8 = diff_xIndex(diffs, num7);
									if (diff.operation == Operation.INSERT)
									{
										text = text.Insert(num5 + num8, diff.text);
									}
									else if (diff.operation == Operation.DELETE)
									{
										text = text.Remove(num5 + num8, diff_xIndex(diffs, num7 + diff.text.Length) - num8);
									}
								}
								if (diff.operation != Operation.DELETE)
								{
									num7 += diff.text.Length;
								}
							}
						}
					}
					else
					{
						text = text.Substring(0, num5) + diff_text2(patch.diffs) + text.Substring(num5 + text3.Length);
					}
				}
				num++;
			}
			text = text.Substring(text2.Length, text.Length - 2 * text2.Length);
			return new object[2] { text, array };
		}
		return new object[2]
		{
			text,
			new bool[0]
		};
	}

	public string patch_addPadding(List<Patch> patches)
	{
		short patch_Margin = Patch_Margin;
		string text = string.Empty;
		for (short num = 1; num <= patch_Margin; num++)
		{
			text += (char)num;
		}
		foreach (Patch patch2 in patches)
		{
			patch2.start1 += patch_Margin;
			patch2.start2 += patch_Margin;
		}
		Patch patch = patches.First();
		List<Diff> diffs = patch.diffs;
		if (diffs.Count != 0 && diffs.First().operation == Operation.EQUAL)
		{
			if (patch_Margin > diffs.First().text.Length)
			{
				Diff diff = diffs.First();
				int num2 = patch_Margin - diff.text.Length;
				diff.text = text.Substring(diff.text.Length) + diff.text;
				patch.start1 -= num2;
				patch.start2 -= num2;
				patch.length1 += num2;
				patch.length2 += num2;
			}
		}
		else
		{
			diffs.Insert(0, new Diff(Operation.EQUAL, text));
			patch.start1 -= patch_Margin;
			patch.start2 -= patch_Margin;
			patch.length1 += patch_Margin;
			patch.length2 += patch_Margin;
		}
		patch = patches.Last();
		diffs = patch.diffs;
		if (diffs.Count != 0 && diffs.Last().operation == Operation.EQUAL)
		{
			if (patch_Margin > diffs.Last().text.Length)
			{
				Diff diff2 = diffs.Last();
				int num3 = patch_Margin - diff2.text.Length;
				diff2.text += text.Substring(0, num3);
				patch.length1 += num3;
				patch.length2 += num3;
			}
		}
		else
		{
			diffs.Add(new Diff(Operation.EQUAL, text));
			patch.length1 += patch_Margin;
			patch.length2 += patch_Margin;
		}
		return text;
	}

	public void patch_splitMax(List<Patch> patches)
	{
		short num = short_0;
		for (int i = 0; i < patches.Count; i++)
		{
			if (patches[i].length1 <= num)
			{
				continue;
			}
			Patch patch = patches[i];
			CompatibilityExtensions.Splice(patches, i--, 1);
			int num2 = patch.start1;
			int num3 = patch.start2;
			string text = string.Empty;
			while (patch.diffs.Count != 0)
			{
				Patch patch2 = new Patch();
				bool flag = true;
				patch2.start1 = num2 - text.Length;
				patch2.start2 = num3 - text.Length;
				if (text.Length != 0)
				{
					patch2.length1 = (patch2.length2 = text.Length);
					patch2.diffs.Add(new Diff(Operation.EQUAL, text));
				}
				while (patch.diffs.Count != 0 && patch2.length1 < num - Patch_Margin)
				{
					Operation operation = patch.diffs[0].operation;
					string text2 = patch.diffs[0].text;
					switch (operation)
					{
					case Operation.INSERT:
						patch2.length2 += text2.Length;
						num3 += text2.Length;
						patch2.diffs.Add(patch.diffs.First());
						patch.diffs.RemoveAt(0);
						flag = false;
						continue;
					case Operation.DELETE:
						if (patch2.diffs.Count == 1 && patch2.diffs.First().operation == Operation.EQUAL && text2.Length > 2 * num)
						{
							patch2.length1 += text2.Length;
							num2 += text2.Length;
							flag = false;
							patch2.diffs.Add(new Diff(operation, text2));
							patch.diffs.RemoveAt(0);
							continue;
						}
						break;
					}
					text2 = text2.Substring(0, Math.Min(text2.Length, num - patch2.length1 - Patch_Margin));
					patch2.length1 += text2.Length;
					num2 += text2.Length;
					if (operation == Operation.EQUAL)
					{
						patch2.length2 += text2.Length;
						num3 += text2.Length;
					}
					else
					{
						flag = false;
					}
					patch2.diffs.Add(new Diff(operation, text2));
					if (text2 == patch.diffs[0].text)
					{
						patch.diffs.RemoveAt(0);
					}
					else
					{
						patch.diffs[0].text = patch.diffs[0].text.Substring(text2.Length);
					}
				}
				text = diff_text2(patch2.diffs);
				text = text.Substring(Math.Max(0, text.Length - Patch_Margin));
				string text3 = null;
				text3 = ((diff_text1(patch.diffs).Length <= Patch_Margin) ? diff_text1(patch.diffs) : diff_text1(patch.diffs).Substring(0, Patch_Margin));
				if (text3.Length != 0)
				{
					patch2.length1 += text3.Length;
					patch2.length2 += text3.Length;
					if (patch2.diffs.Count != 0 && patch2.diffs[patch2.diffs.Count - 1].operation == Operation.EQUAL)
					{
						patch2.diffs[patch2.diffs.Count - 1].text += text3;
					}
					else
					{
						patch2.diffs.Add(new Diff(Operation.EQUAL, text3));
					}
				}
				if (!flag)
				{
					CompatibilityExtensions.Splice(patches, ++i, 0, patch2);
				}
			}
		}
	}

	public string patch_toText(List<Patch> patches)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		foreach (Patch patch in patches)
		{
			stringBuilder.Append(patch);
		}
		stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return stringBuilder.ToString();
	}

	public List<Patch> patch_fromText(string textline)
	{
		List<Patch> list = new List<Patch>();
		if (textline.Length != 0)
		{
			string[] array = textline.Split(new char[1] { '\n' });
			int num = 0;
			Regex regex = new Regex("^@@ -(\\d+),?(\\d*) \\+(\\d+),?(\\d*) @@$");
			while (true)
			{
				if (num < array.Length)
				{
					Match match = regex.Match(array[num]);
					if (!match.Success)
					{
						break;
					}
					Patch patch = new Patch();
					list.Add(patch);
					patch.start1 = Convert.ToInt32(match.Groups[1].Value);
					if (match.Groups[2].Length == 0)
					{
						patch.start1--;
						patch.length1 = 1;
					}
					else if (match.Groups[2].Value == "0")
					{
						patch.length1 = 0;
					}
					else
					{
						patch.start1--;
						patch.length1 = Convert.ToInt32(match.Groups[2].Value);
					}
					patch.start2 = Convert.ToInt32(match.Groups[3].Value);
					if (match.Groups[4].Length == 0)
					{
						patch.start2--;
						patch.length2 = 1;
					}
					else if (!(match.Groups[4].Value == "0"))
					{
						patch.start2--;
						patch.length2 = Convert.ToInt32(match.Groups[4].Value);
					}
					else
					{
						patch.length2 = 0;
					}
					num++;
					while (num < array.Length)
					{
						char c;
						try
						{
							c = array[num][0];
						}
						catch (IndexOutOfRangeException)
						{
							num++;
							continue;
						}
						string text = array[num].Substring(1);
						text = text.Replace("+", "%2b");
						text = HttpUtility.UrlDecode(text);
						if (c == '-')
						{
							patch.diffs.Add(new Diff(Operation.DELETE, text));
						}
						else if (c == '+')
						{
							patch.diffs.Add(new Diff(Operation.INSERT, text));
						}
						else
						{
							if (c != ' ')
							{
								if (c == '@')
								{
									break;
								}
								throw new ArgumentException("Invalid patch mode '" + c + "' in: " + text);
							}
							patch.diffs.Add(new Diff(Operation.EQUAL, text));
						}
						num++;
					}
					continue;
				}
				return list;
			}
			throw new ArgumentException("Invalid patch string: " + array[num]);
		}
		return list;
	}

	public static string smethod_0(string str)
	{
		return new StringBuilder(HttpUtility.UrlEncode(str)).Replace('+', ' ').Replace("%20", " ").Replace("%21", "!")
			.Replace("%2a", "*")
			.Replace("%27", "'")
			.Replace("%28", "(")
			.Replace("%29", ")")
			.Replace("%3b", ";")
			.Replace("%2f", "/")
			.Replace("%3f", "?")
			.Replace("%3a", ":")
			.Replace("%40", "@")
			.Replace("%26", "&")
			.Replace("%3d", "=")
			.Replace("%2b", "+")
			.Replace("%24", "$")
			.Replace("%2c", ",")
			.Replace("%23", "#")
			.Replace("%7e", "~")
			.ToString();
	}

	static diff_match_patch()
	{
		Class72.smethod_20();
	}
}
