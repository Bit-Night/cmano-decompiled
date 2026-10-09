using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Command_Core;

public sealed class nvSorter : IComparer<string>
{
	[DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
	public static extern int StrCmpLogicalW([MarshalAs(UnmanagedType.VBByRefStr)] ref string s1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string s2);

	internal int Compare(string x, string y)
	{
		return StrCmpLogicalW(ref x, ref y);
	}

	int IComparer<string>.Compare(string x, string y)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Compare
		return this.Compare(x, y);
	}

	static nvSorter()
	{
		Class72.smethod_20();
	}
}
