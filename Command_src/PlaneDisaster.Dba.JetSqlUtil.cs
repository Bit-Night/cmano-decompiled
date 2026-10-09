using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace PlaneDisaster.Dba;

public class JetSqlUtil
{
	private enum Enum19
	{

	}

	private enum Enum20
	{

	}

	private static string string_0;

	private static string string_1;

	[DllImport("ODBCCP32.DLL", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern int SQLConfigDataSource(int int_0, Enum19 enum19_0, string string_2, string string_3);

	[DllImport("ODBCCP32.DLL", CharSet = CharSet.Auto)]
	private static extern Enum20 SQLInstallerError(int int_0, ref int int_1, StringBuilder stringBuilder_0, int int_2, ref int int_3);

	public static void smethod_0(string fileName)
	{
		string string_ = string.Format("COMPACT_DB=\"{0}\" \"{0}\" General\0", Path.GetFullPath(fileName));
		if (SQLConfigDataSource(0, (Enum19)1, GetOdbcProviderName(), string_) == 0)
		{
			int int_ = 0;
			int int_2 = 0;
			StringBuilder stringBuilder = new StringBuilder(512);
			SQLInstallerError(1, ref int_, stringBuilder, stringBuilder.MaxCapacity, ref int_2);
			throw new ApplicationException($"Can not compact database:: {fileName}. Error: {stringBuilder}");
		}
	}

	public static void smethod_1(string fileName, AccessDbVersion version = AccessDbVersion.const_2)
	{
		if (File.Exists(fileName))
		{
			File.Delete(fileName);
		}
		string arg = "";
		switch (version)
		{
		case AccessDbVersion.Access95:
			arg = "CREATE_DBV3";
			break;
		case AccessDbVersion.const_1:
			arg = "CREATE_DBV4";
			break;
		case AccessDbVersion.const_2:
			arg = "CREATE_DB";
			break;
		}
		string string_ = $"{arg}=\"{fileName}\" General\0";
		if (SQLConfigDataSource(0, (Enum19)1, GetOdbcProviderName(), string_) == 0)
		{
			int int_ = 0;
			int int_2 = 0;
			StringBuilder stringBuilder = new StringBuilder(512);
			SQLInstallerError(1, ref int_, stringBuilder, stringBuilder.MaxCapacity, ref int_2);
			throw new ApplicationException($"Cannot create file: {fileName}. Error: {stringBuilder}");
		}
	}

	internal static string GetOdbcProviderName()
	{
		if (string.IsNullOrEmpty(string_0))
		{
			List<string> list = new List<string>(Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBCINST.INI\\ODBC Drivers", false).GetValueNames());
			if (list.Contains("Microsoft Access Driver (*.mdb, *.accdb)"))
			{
				string_0 = "Microsoft Access Driver (*.mdb, *.accdb)";
			}
			else
			{
				if (!list.Contains("Microsoft Access Driver (*.mdb)"))
				{
					throw new InvalidOperationException(string.Format("Cannot find an ODBC driver for Microsoft Access. Please download the Microsoft Access Database Engine 2010 Redistributable. {0}", "http://www.microsoft.com/en-us/download/details.aspx?id=13255"));
				}
				string_0 = "Microsoft Access Driver (*.mdb)";
			}
		}
		return string_0;
	}

	internal static string GetOleDbProviderName()
	{
		if (string.IsNullOrEmpty(string_1))
		{
			RegistryKey val = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\CLSID", false);
			List<string> list = new List<string>();
			string[] subKeyNames = val.GetSubKeyNames();
			foreach (string text in subKeyNames)
			{
				RegistryKey obj = val.OpenSubKey(text);
				RegistryKey val2 = obj.OpenSubKey("OLE DB Provider");
				if (obj.GetValue("OLEDB_SERVICES") != null && val2 != null)
				{
					list.Add((string)val2.GetValue(""));
				}
			}
			if (list.Contains("Microsoft Office 12.0 Access Database Engine OLE DB Provider"))
			{
				string_1 = "Microsoft Office 12.0 Access Database Engine OLE DB Provider";
			}
			else
			{
				if (!list.Contains("Microsoft Jet 4.0 OLE DB Provider"))
				{
					throw new InvalidOperationException(string.Format("Cannot find an OleDb driver for Microsoft Access. Please download the Microsoft Access Database Engine 2010 Redistributable. {0}", "http://www.microsoft.com/en-us/download/details.aspx?id=13255"));
				}
				string_1 = "Microsoft Jet 4.0 OLE DB Provider";
			}
		}
		return string_1;
	}

	public static void smethod_2(string fileName)
	{
		string string_ = $"REPAIR_DB=\"{fileName}\"\0";
		if (SQLConfigDataSource(0, (Enum19)1, GetOdbcProviderName(), string_) == 0)
		{
			int int_ = 0;
			int int_2 = 0;
			StringBuilder stringBuilder = new StringBuilder(512);
			SQLInstallerError(1, ref int_, stringBuilder, stringBuilder.MaxCapacity, ref int_2);
			throw new ApplicationException($"Cannot repair database: {fileName}. Error: {stringBuilder}");
		}
	}

	static JetSqlUtil()
	{
		Class72.smethod_20();
	}
}
