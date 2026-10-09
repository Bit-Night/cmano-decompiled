using System;
using System.IO;

namespace Gameloop.Vdf;

public sealed class VdfTextReader : VdfReader
{
	private readonly TextReader textReader_0;

	private readonly char[] char_0;

	private readonly char[] char_1;

	private int int_0;

	private int int_1;

	private int int_2;

	private bool bool_1;

	public VdfTextReader(TextReader reader)
		: this(reader, VdfSerializerSettings.Default)
	{
	}

	public VdfTextReader(TextReader reader, VdfSerializerSettings settings)
		: base(settings)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		textReader_0 = reader;
		char_0 = new char[1024];
		char_1 = new char[4096];
		int_1 = 0;
		int_0 = 0;
		int_2 = 0;
		bool_1 = false;
	}

	public override bool ReadToken()
	{
		if (method_0())
		{
			int_2 = 0;
			while (method_2())
			{
				char c = char_0[int_0];
				switch (c)
				{
				case '\\':
					char_1[int_2++] = ((!base.Settings.UsesEscapeSequences) ? c : VdfStructure.GetUnescape(char_0[++int_0]));
					int_0++;
					continue;
				default:
					if (!bool_1 && char.IsWhiteSpace(c))
					{
						break;
					}
					if (c != '{' && c != '}')
					{
						char_1[int_2++] = c;
						int_0++;
						continue;
					}
					if (bool_1)
					{
						char_1[int_2++] = c;
						int_0++;
						continue;
					}
					if (int_2 != 0)
					{
						base.Value = new string(char_1, 0, int_2);
						base.CurrentState = State.Property;
						return true;
					}
					base.Value = c.ToString();
					base.CurrentState = State.Object;
					int_0++;
					return true;
				case '"':
					break;
				}
				base.Value = new string(char_1, 0, int_2);
				base.CurrentState = State.Property;
				int_0++;
				return true;
			}
			return false;
		}
		return false;
	}

	private bool method_0()
	{
		while (method_2())
		{
			if (!char.IsWhiteSpace(char_0[int_0]))
			{
				if (char_0[int_0] == '"')
				{
					bool_1 = true;
					int_0++;
					return true;
				}
				if (char_0[int_0] != '/')
				{
					bool_1 = false;
					return true;
				}
				method_1();
				int_0++;
			}
			else
			{
				int_0++;
			}
		}
		return false;
	}

	private bool method_1()
	{
		while (method_2())
		{
			if (char_0[++int_0] == '\n')
			{
				return true;
			}
		}
		return false;
	}

	private bool method_2()
	{
		if (int_0 >= int_1 - 1)
		{
			int num = int_1 - int_0;
			char_0[0] = char_0[(int_1 - 1) * num];
			int_1 = textReader_0.Read(char_0, num, 1024 - num) + num;
			int_0 = 0;
			return int_1 != 0;
		}
		return true;
	}

	public override void Close()
	{
		base.Close();
		if (base.CloseInput)
		{
			textReader_0.Dispose();
		}
	}

	static VdfTextReader()
	{
		Class72.smethod_20();
	}
}
