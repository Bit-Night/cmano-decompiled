using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using ScintillaNET;
using ScintillaNET.Demo.Utils;

namespace Command;

public class LuaConsole
{
	private Form form_0;

	[AccessedThroughProperty("TextArea")]
	[CompilerGenerated]
	private Scintilla scintilla_0;

	public virtual Scintilla TextArea
	{
		[CompilerGenerated]
		get
		{
			return scintilla_0;
		}
		[CompilerGenerated]
		set
		{
			scintilla_0 = value;
		}
	}

	public Scintilla ConsoleTextArea => TextArea;

	public LuaConsole(Panel parentForm)
	{
		TextArea = new Scintilla();
		((Control)parentForm).Controls.Add((Control)(object)TextArea);
		form_0 = ((Control)parentForm).FindForm();
		((Control)TextArea).Dock = (DockStyle)5;
		TextArea.WrapMode = WrapMode.None;
		TextArea.IndentationGuides = IndentView.LookBoth;
		method_0();
		method_1();
		method_7();
		method_8();
		method_9();
		method_2();
		TextArea.Styles[32].Font = ((Control)parentForm).Font.FontFamily.Name;
	}

	private void method_0()
	{
		TextArea.SetSelectionBackColor(use: true, Color.FromArgb(1133980));
	}

	private void method_1()
	{
		string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text2 = "0123456789";
		string text3 = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
		bool useDarkThemeOnLuaConsoles = SimConfiguration.DefaultGamePreferences.UseDarkThemeOnLuaConsoles;
		TextArea.StyleResetDefault();
		TextArea.Styles[32].Font = "Consolas";
		TextArea.Styles[32].Size = 10;
		if (useDarkThemeOnLuaConsoles)
		{
			TextArea.Styles[32].BackColor = Color.FromArgb(69, 73, 74);
			TextArea.Styles[32].ForeColor = Color.White;
			TextArea.CaretForeColor = Color.White;
		}
		TextArea.StyleClearAll();
		if (useDarkThemeOnLuaConsoles)
		{
			TextArea.Styles[0].ForeColor = Color.Silver;
			TextArea.Styles[1].ForeColor = Color.LightGreen;
			TextArea.Styles[2].ForeColor = Color.LightGreen;
			TextArea.Styles[4].ForeColor = Color.GreenYellow;
			TextArea.Styles[5].ForeColor = Color.LightBlue;
			TextArea.Styles[13].ForeColor = Color.MediumSlateBlue;
			TextArea.Styles[14].ForeColor = Color.LightSteelBlue;
			TextArea.Styles[15].ForeColor = Color.DarkSlateBlue;
			TextArea.Styles[6].ForeColor = Color.OrangeRed;
			TextArea.Styles[7].ForeColor = Color.Khaki;
			TextArea.Styles[8].ForeColor = Color.DarkKhaki;
			TextArea.Styles[12].BackColor = Color.OliveDrab;
			TextArea.Styles[10].ForeColor = Color.Orange;
			TextArea.Styles[9].ForeColor = Color.Maroon;
			TextArea.Styles[16].ForeColor = Color.LightGoldenrodYellow;
		}
		else
		{
			TextArea.Styles[0].ForeColor = Color.Silver;
			TextArea.Styles[1].ForeColor = Color.LightGreen;
			TextArea.Styles[2].ForeColor = Color.DarkSlateGray;
			TextArea.Styles[4].ForeColor = Color.Olive;
			TextArea.Styles[5].ForeColor = Color.Blue;
			TextArea.Styles[13].ForeColor = Color.BlueViolet;
			TextArea.Styles[14].ForeColor = Color.DarkSlateBlue;
			TextArea.Styles[15].ForeColor = Color.DarkSlateBlue;
			TextArea.Styles[6].ForeColor = Color.Red;
			TextArea.Styles[7].ForeColor = Color.Red;
			TextArea.Styles[8].ForeColor = Color.Red;
			TextArea.Styles[12].BackColor = Color.Pink;
			TextArea.Styles[10].ForeColor = Color.Purple;
			TextArea.Styles[9].ForeColor = Color.Maroon;
			TextArea.Styles[16].ForeColor = Color.Goldenrod;
		}
		TextArea.Lexer = Lexer.Lua;
		TextArea.WordChars = text + text2 + text3;
		TextArea.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while false true goto");
		TextArea.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
		TextArea.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
		TextArea.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath require package.cpath package.loaded package.loadlib package.path package.preload");
		TextArea.SetProperty("fold", "1");
		TextArea.SetProperty("fold.compact", "1");
		TextArea.Margins[2].Type = MarginType.Symbol;
		TextArea.Margins[2].Mask = 4261412864u;
		TextArea.Margins[2].Sensitive = true;
		TextArea.Margins[2].Width = 20;
		int num = 25;
		do
		{
			TextArea.Markers[num].SetForeColor(SystemColors.ControlLightLight);
			TextArea.Markers[num].SetBackColor(SystemColors.ControlDark);
			num++;
		}
		while (num <= 31);
		TextArea.Markers[30].Symbol = MarkerSymbol.BoxPlus;
		TextArea.Markers[31].Symbol = MarkerSymbol.BoxMinus;
		TextArea.Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
		TextArea.Markers[27].Symbol = MarkerSymbol.TCorner;
		TextArea.Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
		TextArea.Markers[29].Symbol = MarkerSymbol.VLine;
		TextArea.Markers[28].Symbol = MarkerSymbol.LCorner;
		TextArea.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
		string[] array = LuaSandBox.LuaMethods.OrderBy([SpecialName] (string s) => s).ToArray();
		string text4 = "";
		char c = '(';
		string[] array2 = array;
		foreach (string text5 in array2)
		{
			text4 = text4 + text5.Split(new char[1] { c })[0] + " ";
		}
		TextArea.SetKeywords(4, text4);
	}

	private void method_2()
	{
		HotKeyManager.AddHotKey(form_0, method_6, (Keys)106, ctrl: true);
		HotKeyManager.AddHotKey(form_0, method_3, (Keys)187, ctrl: true);
		HotKeyManager.AddHotKey(form_0, method_4, (Keys)189, ctrl: true);
		TextArea.ClearCmdKey((Keys)131142);
		TextArea.ClearCmdKey((Keys)131154);
		TextArea.ClearCmdKey((Keys)131144);
		TextArea.ClearCmdKey((Keys)131148);
		TextArea.ClearCmdKey((Keys)131157);
	}

	private void method_3()
	{
		TextArea.ZoomIn();
	}

	private void method_4()
	{
		TextArea.ZoomOut();
	}

	private void method_5()
	{
		TextArea.Zoom = 0;
	}

	private void method_6()
	{
		if (TextArea.WrapMode != WrapMode.None)
		{
			TextArea.WrapMode = WrapMode.None;
		}
		else
		{
			TextArea.WrapMode = WrapMode.Word;
		}
	}

	private void method_7()
	{
		TextArea.Styles[33].BackColor = IntToColor(2760988);
		TextArea.Styles[33].ForeColor = IntToColor(12040119);
		TextArea.Styles[37].ForeColor = IntToColor(12040119);
		TextArea.Styles[37].BackColor = IntToColor(2760988);
		Margin margin = TextArea.Margins[1];
		margin.Width = 30;
		margin.Type = MarginType.Number;
		margin.Sensitive = true;
		margin.Mask = 0u;
		TextArea.MarginClick += method_10;
	}

	private void method_8()
	{
		Margin margin = TextArea.Margins[2];
		margin.Width = 20;
		margin.Sensitive = true;
		margin.Type = MarginType.Symbol;
		margin.Mask = 4u;
		Marker marker = TextArea.Markers[2];
		marker.Symbol = MarkerSymbol.Circle;
		marker.SetBackColor(IntToColor(16711739));
		marker.SetForeColor(IntToColor(0));
		marker.SetAlpha(100);
	}

	private void method_9()
	{
		TextArea.SetFoldMarginColor(use: true, IntToColor(2760988));
		TextArea.SetFoldMarginHighlightColor(use: true, IntToColor(2760988));
		TextArea.SetProperty("fold", "1");
		TextArea.SetProperty("fold.compact", "1");
		TextArea.Margins[3].Type = MarginType.Symbol;
		TextArea.Margins[3].Mask = 4261412864u;
		TextArea.Margins[3].Sensitive = true;
		TextArea.Margins[3].Width = 20;
		int num = 25;
		do
		{
			TextArea.Markers[num].SetForeColor(IntToColor(2760988));
			TextArea.Markers[num].SetBackColor(IntToColor(12040119));
			num++;
		}
		while (num <= 31);
		TextArea.Markers[30].Symbol = MarkerSymbol.CirclePlus;
		TextArea.Markers[31].Symbol = MarkerSymbol.CircleMinus;
		TextArea.Markers[25].Symbol = MarkerSymbol.CirclePlusConnected;
		TextArea.Markers[27].Symbol = MarkerSymbol.TCorner;
		TextArea.Markers[26].Symbol = MarkerSymbol.CircleMinusConnected;
		TextArea.Markers[29].Symbol = MarkerSymbol.VLine;
		TextArea.Markers[28].Symbol = MarkerSymbol.LCorner;
		TextArea.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
	}

	private void method_10(object sender, MarginClickEventArgs e)
	{
		if (e.Margin == 2)
		{
			Line line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
			if ((long)(line.MarkerGet() & 4) > 0L)
			{
				line.MarkerDelete(2);
			}
			else
			{
				line.MarkerAdd(2);
			}
		}
	}

	public static Color IntToColor(int rgb)
	{
		return Color.FromArgb(rgb);
	}

	static LuaConsole()
	{
		Class72.smethod_20();
	}
}
