using System;
using System.IO;
using System.Text;

namespace Nini.Ini;

public class IniWriter : IDisposable
{
	private int int_0;

	private bool bool_0;

	private IniWriteState iniWriteState_0;

	private char char_0 = ';';

	private char char_1 = '=';

	private TextWriter textWriter_0;

	private string string_0 = "\r\n";

	private StringBuilder stringBuilder_0 = new StringBuilder();

	private Stream stream_0;

	private bool bool_1;

	public int Indentation
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value >= 0)
			{
				int_0 = value;
				stringBuilder_0.Remove(0, stringBuilder_0.Length);
				for (int i = 0; i < value; i++)
				{
					stringBuilder_0.Append(' ');
				}
				return;
			}
			throw new ArgumentException("Negative values are illegal");
		}
	}

	public bool UseValueQuotes
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

	public IniWriteState WriteState => iniWriteState_0;

	public char CommentDelimiter
	{
		get
		{
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

	public char AssignDelimiter
	{
		get
		{
			return char_1;
		}
		set
		{
			char_1 = value;
		}
	}

	public Stream BaseStream => stream_0;

	public IniWriter(string filePath)
		: this(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
	{
	}

	public IniWriter(TextWriter writer)
	{
		textWriter_0 = writer;
		if (writer is StreamWriter streamWriter)
		{
			stream_0 = streamWriter.BaseStream;
		}
	}

	public IniWriter(Stream stream)
		: this(new StreamWriter(stream))
	{
	}

	public void Close()
	{
		textWriter_0.Close();
		iniWriteState_0 = IniWriteState.Closed;
	}

	public void Flush()
	{
		textWriter_0.Flush();
	}

	public override string ToString()
	{
		return textWriter_0.ToString();
	}

	public void WriteSection(string section)
	{
		method_2();
		iniWriteState_0 = IniWriteState.Section;
		cNryIvQwGq2("[" + section + "]");
	}

	public void WriteSection(string section, string comment)
	{
		method_2();
		iniWriteState_0 = IniWriteState.Section;
		cNryIvQwGq2("[" + section + "]" + method_3(comment));
	}

	public void WriteKey(string key, string value)
	{
		method_1();
		cNryIvQwGq2(key + " " + char_1 + " " + method_0(value));
	}

	public void WriteKey(string key, string value, string comment)
	{
		method_1();
		cNryIvQwGq2(key + " " + char_1 + " " + method_0(value) + method_3(comment));
	}

	public void WriteEmpty()
	{
		method_2();
		if (iniWriteState_0 == IniWriteState.Start)
		{
			iniWriteState_0 = IniWriteState.BeforeFirstSection;
		}
		cNryIvQwGq2("");
	}

	public void WriteEmpty(string comment)
	{
		method_2();
		if (iniWriteState_0 == IniWriteState.Start)
		{
			iniWriteState_0 = IniWriteState.BeforeFirstSection;
		}
		if (comment == null)
		{
			cNryIvQwGq2("");
		}
		else
		{
			cNryIvQwGq2(char_0 + " " + comment);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_1)
		{
			if (textWriter_0 != null)
			{
				textWriter_0.Close();
			}
			if (stream_0 != null)
			{
				stream_0.Close();
			}
			bool_1 = true;
			if (disposing)
			{
				GC.SuppressFinalize(this);
			}
		}
	}

	~IniWriter()
	{
		Dispose(disposing: false);
	}

	private string method_0(string string_1)
	{
		if (bool_0)
		{
			return method_4("\"" + string_1 + "\"");
		}
		return method_4(string_1);
	}

	private void method_1()
	{
		method_2();
		switch (iniWriteState_0)
		{
		case IniWriteState.Start:
		case IniWriteState.BeforeFirstSection:
			throw new InvalidOperationException("The WriteState is not Section");
		case IniWriteState.Closed:
			throw new InvalidOperationException("The writer is closed");
		}
	}

	private void method_2()
	{
		if (iniWriteState_0 == IniWriteState.Closed)
		{
			throw new InvalidOperationException("The writer is closed");
		}
	}

	private string method_3(string string_1)
	{
		if (string_1 != null)
		{
			return " " + char_0 + " " + string_1;
		}
		return "";
	}

	private void Write(string value)
	{
		textWriter_0.Write(stringBuilder_0.ToString() + value);
	}

	private void cNryIvQwGq2(string string_1)
	{
		Write(string_1 + string_0);
	}

	private string method_4(string string_1)
	{
		return string_1.Replace("\n", "");
	}

	static IniWriter()
	{
		Class72.smethod_20();
	}
}
