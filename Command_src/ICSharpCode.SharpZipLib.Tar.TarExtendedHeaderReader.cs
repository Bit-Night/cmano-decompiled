using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar;

public class TarExtendedHeaderReader
{
	private readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private string[] string_0 = new string[3];

	private int int_0;

	private byte[] byte_0;

	private char[] char_0;

	private readonly StringBuilder stringBuilder_0 = new StringBuilder();

	private readonly Decoder decoder_0 = Encoding.UTF8.GetDecoder();

	private int int_1;

	private int int_2;

	private int int_3;

	private static readonly byte[] byte_1;

	public Dictionary<string, string> Headers => dictionary_0;

	public TarExtendedHeaderReader()
	{
		method_0();
	}

	public void Read(byte[] buffer, int length)
	{
		for (int i = 0; i < length; i++)
		{
			byte b = buffer[i];
			if ((int_1 == 2) ? (int_3 == int_2 - 1) : (b == byte_1[int_1]))
			{
				HwxyVmOvRyo();
				string_0[int_1] = stringBuilder_0.ToString();
				stringBuilder_0.Clear();
				if (++int_1 == 3)
				{
					if (!dictionary_0.ContainsKey(string_0[1]))
					{
						dictionary_0.Add(string_0[1], string_0[2]);
					}
					string_0 = new string[3];
					int_2 = 0;
					int_3 = 0;
					int_1 = 0;
				}
				else
				{
					int_3++;
				}
				if (int_1 == 2 && int.TryParse(string_0[0], out var result))
				{
					int_2 = result;
				}
			}
			else
			{
				byte_0[int_0++] = b;
				int_3++;
				if (int_0 == 4)
				{
					HwxyVmOvRyo();
				}
			}
		}
	}

	private void HwxyVmOvRyo()
	{
		decoder_0.Convert(byte_0, 0, int_0, char_0, 0, 4, flush: false, out var _, out var charsUsed, out var _);
		stringBuilder_0.Append(char_0, 0, charsUsed);
		method_0();
	}

	private void method_0()
	{
		char_0 = new char[4];
		byte_0 = new byte[4];
		int_0 = 0;
	}

	static TarExtendedHeaderReader()
	{
		Class72.smethod_20();
		byte_1 = new byte[3] { 32, 61, 10 };
	}
}
