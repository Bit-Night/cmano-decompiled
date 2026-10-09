using System;
using System.IO;
using System.Runtime.CompilerServices;
using MapReduce.NET.Collections.System.IO;

namespace MapReduce.NET.Input;

public class TextfileLineInput : InputPlugin<string>
{
	private StreamReaderAdvanced streamReaderAdvanced_0;

	private int int_0;

	private string[] string_0;

	private int int_1;

	[CompilerGenerated]
	private DateTime? nullable_0;

	[CompilerGenerated]
	private DateTime? nullable_1;

	public DateTime? CreationDateAtLeast
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public DateTime? CreationDateAtMost
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	public TextfileLineInput(string path)
		: base((object)path)
	{
	}

	protected internal override void Open()
	{
		string text = Path.GetDirectoryName(base.Location.ToString());
		string fileName = Path.GetFileName(base.Location.ToString());
		if (string.IsNullOrEmpty(text))
		{
			text = ".";
		}
		string_0 = Directory.GetFiles(text, fileName);
	}

	protected override void CloseInput()
	{
	}

	protected override bool ReadItem(out string data, out object index)
	{
		if (streamReaderAdvanced_0 == null)
		{
			base.Location = string_0[int_1++];
			streamReaderAdvanced_0 = new StreamReaderAdvanced(base.Location.ToString());
		}
		string text = streamReaderAdvanced_0.ReadLine();
		if (text == null)
		{
			if (int_1 == string_0.Length)
			{
				data = null;
				index = -1;
				return false;
			}
			index = 0;
			streamReaderAdvanced_0 = null;
			return ReadItem(out data, out index);
		}
		index = int_0;
		int_0 = (int)streamReaderAdvanced_0.Position;
		data = text;
		return true;
	}

	static TextfileLineInput()
	{
		Class72.smethod_20();
	}
}
