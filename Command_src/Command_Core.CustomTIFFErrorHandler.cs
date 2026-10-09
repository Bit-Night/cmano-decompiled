using System;
using System.Diagnostics;
using System.IO;
using BitMiracle.LibTiff.Classic;

namespace Command_Core;

internal class CustomTIFFErrorHandler : TiffErrorHandler
{
	public override void ErrorHandler(Tiff tif, string module, string fmt, params object[] ap)
	{
		_ = Debugger.IsAttached;
		using TextWriter textWriter = Console.Out;
		if (module != null)
		{
			textWriter.Write("{0}: ", module);
		}
		textWriter.Write(fmt, ap);
		textWriter.Write(".\n");
	}

	public override void WarningHandler(Tiff tif, string module, string fmt, params object[] ap)
	{
	}

	static CustomTIFFErrorHandler()
	{
		Class72.smethod_20();
	}
}
