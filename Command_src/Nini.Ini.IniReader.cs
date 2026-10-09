using System;
using System.IO;
using System.Text;

namespace Nini.Ini;

public class IniReader : IDisposable
{
	private int int_0 = 1;

	private int int_1 = 1;

	private IniType iniType_0 = IniType.Empty;

	private TextReader textReader_0;

	private bool bool_0;

	private StringBuilder stringBuilder_0 = new StringBuilder();

	private StringBuilder stringBuilder_1 = new StringBuilder();

	private StringBuilder stringBuilder_2 = new StringBuilder();

	private IniReadState kSnyIqktVvS = IniReadState.Initial;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4 = true;

	private bool bool_5;

	private bool bool_6;

	private char[] char_0 = new char[1] { ';' };

	private char[] char_1 = new char[1] { '=' };

	public string Name => stringBuilder_0.ToString();

	public string Value => stringBuilder_1.ToString();

	public IniType Type => iniType_0;

	public string Comment
	{
		get
		{
			if (bool_1)
			{
				return stringBuilder_2.ToString();
			}
			return null;
		}
	}

	public int LineNumber => int_0;

	public int LinePosition => int_1;

	public bool IgnoreComments
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public IniReadState ReadState => kSnyIqktVvS;

	public bool LineContinuation
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool AcceptCommentAfterKey
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool AcceptNoAssignmentOperator
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool ConsumeAllKeyText
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public IniReader(string filePath)
	{
		textReader_0 = new StreamReader(filePath);
	}

	public IniReader(TextReader reader)
	{
		textReader_0 = reader;
	}

	public IniReader(Stream stream)
		: this(new StreamReader(stream))
	{
	}

	public bool Read()
	{
		bool result = false;
		if (kSnyIqktVvS != IniReadState.EndOfFile || kSnyIqktVvS != IniReadState.Closed)
		{
			kSnyIqktVvS = IniReadState.Interactive;
			result = method_0();
		}
		return result;
	}

	public bool MoveToNextSection()
	{
		bool flag = false;
		do
		{
			flag = Read();
		}
		while (iniType_0 != IniType.Section && flag);
		return flag;
	}

	public bool MoveToNextKey()
	{
		bool flag = false;
		do
		{
			flag = Read();
			if (iniType_0 == IniType.Section)
			{
				flag = false;
				break;
			}
		}
		while (iniType_0 != IniType.Key && flag);
		return flag;
	}

	public void Close()
	{
		Reset();
		kSnyIqktVvS = IniReadState.Closed;
		if (textReader_0 != null)
		{
			textReader_0.Close();
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	public char[] GetCommentDelimiters()
	{
		char[] array = new char[char_0.Length];
		Array.Copy(char_0, 0, array, 0, char_0.Length);
		return array;
	}

	public void SetCommentDelimiters(char[] delimiters)
	{
		if (delimiters.Length < 1)
		{
			throw new ArgumentException("Must supply at least one delimiter");
		}
		char_0 = delimiters;
	}

	public char[] GetAssignDelimiters()
	{
		char[] array = new char[char_1.Length];
		Array.Copy(char_1, 0, array, 0, char_1.Length);
		return array;
	}

	public void SetAssignDelimiters(char[] delimiters)
	{
		if (delimiters.Length < 1)
		{
			throw new ArgumentException("Must supply at least one delimiter");
		}
		char_1 = delimiters;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_2)
		{
			textReader_0.Close();
			bool_2 = true;
			if (disposing)
			{
				GC.SuppressFinalize(this);
			}
		}
	}

	~IniReader()
	{
		Dispose(disposing: false);
	}

	private void Reset()
	{
		stringBuilder_0.Remove(0, stringBuilder_0.Length);
		stringBuilder_1.Remove(0, stringBuilder_1.Length);
		stringBuilder_2.Remove(0, stringBuilder_2.Length);
		iniType_0 = IniType.Empty;
		bool_1 = false;
	}

	private bool method_0()
	{
		bool result = true;
		int num = method_9();
		Reset();
		if (method_10(num))
		{
			iniType_0 = IniType.Empty;
			method_8();
			method_1();
			return result;
		}
		switch (num)
		{
		case 10:
			method_8();
			break;
		case -1:
			kSnyIqktVvS = IniReadState.EndOfFile;
			result = false;
			break;
		default:
			method_3();
			break;
		case 91:
			method_5();
			break;
		case 9:
		case 13:
		case 32:
			method_14();
			method_0();
			break;
		}
		return result;
	}

	private void method_1()
	{
		int num = -1;
		method_14();
		bool_1 = true;
		do
		{
			num = method_8();
			stringBuilder_2.Append((char)num);
		}
		while (!method_15(num));
		method_2(stringBuilder_2);
	}

	private void method_2(StringBuilder stringBuilder_3)
	{
		string text = stringBuilder_3.ToString();
		stringBuilder_3.Remove(0, stringBuilder_3.Length);
		stringBuilder_3.Append(text.TrimEnd(null));
	}

	private void method_3()
	{
		int num = -1;
		iniType_0 = IniType.Key;
		while (true)
		{
			num = method_9();
			if (!method_11(num))
			{
				if (!method_15(num))
				{
					stringBuilder_0.Append((char)method_8());
					continue;
				}
				if (bool_5)
				{
					break;
				}
				throw new IniException(this, $"Expected assignment operator ({char_1[0]})");
			}
			method_8();
			break;
		}
		method_4();
		method_6();
		method_2(stringBuilder_0);
	}

	private void method_4()
	{
		int num = -1;
		bool flag = false;
		int num2 = 0;
		method_14();
		while (true)
		{
			num = method_9();
			if (!method_13(num))
			{
				num2++;
			}
			if (!ConsumeAllKeyText && num == 34)
			{
				method_8();
				if (flag || num2 != 1)
				{
					break;
				}
				flag = true;
				continue;
			}
			if (!flag || !method_15(num))
			{
				if (bool_3 && num == 92)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append((char)method_8());
					while (method_9() != 10 && method_13(method_9()))
					{
						if (method_9() != 13)
						{
							stringBuilder.Append((char)method_8());
						}
						else
						{
							method_8();
						}
					}
					if (method_9() == 10)
					{
						method_8();
						continue;
					}
					stringBuilder_1.Append(stringBuilder.ToString());
				}
				if ((!ConsumeAllKeyText && bool_4 && method_10(num) && !flag) || method_15(num))
				{
					break;
				}
				stringBuilder_1.Append((char)method_8());
				continue;
			}
			throw new IniException(this, "Expected closing quote (\")");
		}
		if (!flag)
		{
			method_2(stringBuilder_1);
		}
	}

	private void method_5()
	{
		int num = -1;
		iniType_0 = IniType.Section;
		num = method_8();
		while (true)
		{
			num = method_9();
			if (num == 93)
			{
				break;
			}
			if (!method_15(num))
			{
				stringBuilder_0.Append((char)method_8());
				continue;
			}
			throw new IniException(this, "Expected section end (])");
		}
		method_7();
		method_2(stringBuilder_0);
	}

	private void method_6()
	{
		int int_ = method_8();
		while (true)
		{
			if (!method_15(int_))
			{
				if (method_10(int_))
				{
					break;
				}
				int_ = method_8();
				continue;
			}
			return;
		}
		if (!bool_0)
		{
			method_1();
		}
		else
		{
			method_7();
		}
	}

	private void method_7()
	{
		int num = -1;
		do
		{
			num = method_8();
		}
		while (!method_15(num));
	}

	private int method_8()
	{
		int num = textReader_0.Read();
		if (num == 10)
		{
			int_0++;
			int_1 = 1;
			return num;
		}
		int_1++;
		return num;
	}

	private int method_9()
	{
		return textReader_0.Peek();
	}

	private bool method_10(int int_2)
	{
		return method_12(char_0, int_2);
	}

	private bool method_11(int int_2)
	{
		return method_12(char_1, int_2);
	}

	private bool method_12(char[] char_2, int int_2)
	{
		bool result = false;
		for (int i = 0; i < char_2.Length; i++)
		{
			if (int_2 == char_2[i])
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private bool method_13(int int_2)
	{
		if (int_2 != 32 && int_2 != 9 && int_2 != 13)
		{
			return int_2 == 10;
		}
		return true;
	}

	private void method_14()
	{
		while (method_13(method_9()) && !method_15(method_9()))
		{
			method_8();
		}
	}

	private bool method_15(int int_2)
	{
		if (int_2 != 10)
		{
			return int_2 == -1;
		}
		return true;
	}

	static IniReader()
	{
		Class72.smethod_20();
	}
}
