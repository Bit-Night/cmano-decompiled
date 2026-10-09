using System;
using System.IO;
using Gameloop.Vdf.Linq;

namespace Gameloop.Vdf;

public sealed class VdfTextWriter : VdfWriter
{
	private readonly TextWriter textWriter_0;

	private int int_0;

	public VdfTextWriter(TextWriter writer)
		: this(writer, VdfSerializerSettings.Default)
	{
	}

	public VdfTextWriter(TextWriter writer, VdfSerializerSettings settings)
		: base(settings)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		textWriter_0 = writer;
		int_0 = 0;
	}

	public override void WriteKey(string key)
	{
		method_0(State.Key);
		textWriter_0.Write('"');
		method_1(key);
		textWriter_0.Write('"');
	}

	public override void WriteValue(VValue value)
	{
		method_0(State.Value);
		textWriter_0.Write('"');
		method_1(value.ToString());
		textWriter_0.Write('"');
	}

	public override void WriteObjectStart()
	{
		method_0(State.ObjectStart);
		textWriter_0.Write('{');
		int_0++;
	}

	public override void WriteObjectEnd()
	{
		int_0--;
		method_0(State.ObjectEnd);
		textWriter_0.Write('}');
		if (int_0 == 0)
		{
			method_0(State.Finished);
		}
	}

	private void method_0(State state_1)
	{
		if (base.CurrentState == State.Start)
		{
			base.CurrentState = state_1;
			return;
		}
		switch (state_1)
		{
		case State.Value:
			textWriter_0.Write(' ');
			break;
		case State.Key:
		case State.ObjectStart:
		case State.ObjectEnd:
			textWriter_0.WriteLine();
			textWriter_0.Write(new string('\t', int_0));
			break;
		case State.Finished:
			textWriter_0.WriteLine();
			break;
		}
		base.CurrentState = state_1;
	}

	private void method_1(string string_0)
	{
		if (!base.Settings.UsesEscapeSequences)
		{
			textWriter_0.Write(string_0);
			return;
		}
		foreach (char c in string_0)
		{
			if (!VdfStructure.IsEscapable(c))
			{
				textWriter_0.Write(c);
				continue;
			}
			textWriter_0.Write('\\');
			textWriter_0.Write(VdfStructure.GetEscape(c));
		}
	}

	public override void Close()
	{
		base.Close();
		if (base.CloseOutput)
		{
			textWriter_0.Dispose();
		}
	}

	static VdfTextWriter()
	{
		Class72.smethod_20();
	}
}
