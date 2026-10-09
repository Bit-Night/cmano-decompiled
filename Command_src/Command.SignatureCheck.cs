using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class SignatureCheck
{
	private static HashSet<string> hashSet_0;

	static SignatureCheck()
	{
		Class72.smethod_20();
		hashSet_0 = new HashSet<string>(new List<string>(new string[3] { "00FC5B076FCD201FD9426461284218C908", "00C52B4209DA0B5B12F8197E35D195607A", "148AA83C98560DDB09B5D51CD4117721" }));
	}

	public static bool ExeHasValidCertificate(string theFileName)
	{
		string item = smethod_0(theFileName);
		if (!hashSet_0.Contains(item))
		{
			return false;
		}
		return true;
	}

	private static string smethod_0(string string_0)
	{
		try
		{
			Runspace runspace = RunspaceFactory.CreateRunspace(RunspaceConfiguration.Create());
			runspace.Open();
			Pipeline pipeline = runspace.CreatePipeline();
			pipeline.Commands.AddScript("Get-AuthenticodeSignature \"" + string_0 + "\"");
			Collection<PSObject> collection = pipeline.Invoke();
			runspace.Close();
			if (!(collection[0].BaseObject is Signature signature))
			{
				return string.Empty;
			}
			switch (signature.Status)
			{
			default:
				if (System.Diagnostics.Debugger.IsAttached)
				{
					System.Diagnostics.Debugger.Break();
				}
				return string.Empty;
			case SignatureStatus.Valid:
				return signature.SignerCertificate.SerialNumber;
			case SignatureStatus.UnknownError:
				return string.Empty;
			case SignatureStatus.NotSigned:
				return string.Empty;
			case SignatureStatus.HashMismatch:
				return string.Empty;
			case SignatureStatus.NotTrusted:
				return string.Empty;
			case SignatureStatus.NotSupportedFileFormat:
				return string.Empty;
			case SignatureStatus.Incompatible:
				return string.Empty;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception("Error when trying to check if file is signed:" + string_0 + " --> " + ex2.Message);
		}
	}
}
