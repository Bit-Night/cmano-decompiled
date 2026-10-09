using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Licensing_PE
{
	public delegate void LicensingCheckErrorOccuredEventHandler(string theErrorMessage);

	public enum ProgramExecutionMode
	{
		Undefined,
		FullGUIClient,
		CLI,
		MP_Server
	}

	public enum ProExtension
	{
		TestScripts
	}

	public enum _ProLicenseVersion
	{
		FullVersion,
		EvaluationVersion
	}

	[CompilerGenerated]
	private static LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler_0;

	private static int int_0;

	public static event LicensingCheckErrorOccuredEventHandler LicensingCheckErrorOccured
	{
		[CompilerGenerated]
		add
		{
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler = licensingCheckErrorOccuredEventHandler_0;
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler2;
			do
			{
				licensingCheckErrorOccuredEventHandler2 = licensingCheckErrorOccuredEventHandler;
				LicensingCheckErrorOccuredEventHandler value2 = (LicensingCheckErrorOccuredEventHandler)Delegate.Combine(licensingCheckErrorOccuredEventHandler2, value);
				licensingCheckErrorOccuredEventHandler = Interlocked.CompareExchange(ref licensingCheckErrorOccuredEventHandler_0, value2, licensingCheckErrorOccuredEventHandler2);
			}
			while ((object)licensingCheckErrorOccuredEventHandler != licensingCheckErrorOccuredEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler = licensingCheckErrorOccuredEventHandler_0;
			LicensingCheckErrorOccuredEventHandler licensingCheckErrorOccuredEventHandler2;
			do
			{
				licensingCheckErrorOccuredEventHandler2 = licensingCheckErrorOccuredEventHandler;
				LicensingCheckErrorOccuredEventHandler value2 = (LicensingCheckErrorOccuredEventHandler)Delegate.Remove(licensingCheckErrorOccuredEventHandler2, value);
				licensingCheckErrorOccuredEventHandler = Interlocked.CompareExchange(ref licensingCheckErrorOccuredEventHandler_0, value2, licensingCheckErrorOccuredEventHandler2);
			}
			while ((object)licensingCheckErrorOccuredEventHandler != licensingCheckErrorOccuredEventHandler2);
		}
	}

	static Licensing_PE()
	{
		Class72.smethod_20();
		int_0 = 0;
	}

	public static string StripLastSegmentIfFive(string input)
	{
		if (!string.IsNullOrEmpty(input))
		{
			if (input.Split(new char[1] { '-' }).Length == 5)
			{
				return input[..input.LastIndexOf('-')];
			}
			return input;
		}
		return input;
	}

	public static string LoadAndParsePELicense(string theFileName, ProgramExecutionMode theMode)
	{
		string result = default(string);
		return result;
	}

	public static string AttemptToObtainFloatingLicense()
	{
		string result = default(string);
		return result;
	}

	public static void AttemptToReturnFloatingLicense()
	{
	}

	private static void smethod_0(object object_0, object object_1)
	{
	}
}
