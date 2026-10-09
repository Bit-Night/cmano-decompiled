using System;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.mdb2sq3;

public class CommandLineParametersHelper
{
	public static string databaseSource;

	public static string databaseTarget;

	public static string databaseHost;

	public static bool verbose;

	public static bool erase;

	static CommandLineParametersHelper()
	{
		Class72.smethod_20();
		databaseSource = null;
		databaseTarget = null;
		databaseHost = null;
		verbose = false;
		erase = false;
	}

	public static bool ParseArguments(string[] args)
	{
		bool result;
		try
		{
			foreach (string text in args)
			{
				if (!text.ToUpperInvariant().StartsWith("-S:"))
				{
					if (!text.ToUpperInvariant().StartsWith("-T:"))
					{
						if (text.ToUpperInvariant().StartsWith("-E"))
						{
							erase = true;
							continue;
						}
						if (text.ToUpperInvariant().StartsWith("-V"))
						{
							verbose = true;
							continue;
						}
						if (!text.ToUpperInvariant().StartsWith("-?"))
						{
							Console.WriteLine($"ERROR: Unknown parameter {text}");
							result = false;
						}
						else
						{
							Console.WriteLine("mdb2sq3: Converts a simple MSAccess Database file into a SQLite database.");
							Console.WriteLine("usage:");
							Console.WriteLine("mdb2sq3 -s:sourcefile [-t:targetfile] [options]");
							Console.WriteLine(" -s:sourcefile   Sets the source MSAccess database");
							Console.WriteLine(" -t:targetfile   Sets the target SQLite database");
							Console.WriteLine(" -e              Forces deletion of target file if it exists");
							Console.WriteLine(" -v              Verbose mode.");
							Console.WriteLine(" -?              Prints this help and exits the program.");
							result = false;
						}
						goto IL_0172;
					}
					databaseTarget = text.Substring(3);
					continue;
				}
				databaseSource = text.Substring(3);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Console.WriteLine("ERROR: Invalid parameter value.");
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0172;
		}
		if (databaseSource == null)
		{
			Console.WriteLine($"ERROR: You need to set MsAccess Database source file");
			result = false;
		}
		else if (File.Exists(databaseSource))
		{
			result = true;
		}
		else
		{
			Console.WriteLine($"ERROR: source file cannot be found");
			result = false;
		}
		goto IL_0172;
		IL_0172:
		return result;
	}
}
