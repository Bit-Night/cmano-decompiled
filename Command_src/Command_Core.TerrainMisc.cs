using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class TerrainMisc
{
	private struct Struct28
	{
		public short short_0;

		public short short_1;

		public Struct28(short short_2, short short_3)
		{
			this = default(Struct28);
			short_0 = 0;
			short_1 = 0;
		}

		static Struct28()
		{
			Class72.smethod_20();
		}
	}

	private static Struct28[][] tRayeVkOrMl;

	private static Dictionary<int, Dictionary<int, float>> dictionary_0;

	private static bool bool_0;

	static TerrainMisc()
	{
		Class72.smethod_20();
		tRayeVkOrMl = new Struct28[360][];
		bool_0 = false;
	}

	private static Struct28 smethod_0(object object_0, int int_0, int int_1)
	{
		Struct28 result;
		try
		{
			if (((object[])object_0)[int_0] == null)
			{
				result = default(Struct28);
			}
			else
			{
				Struct28[] array = (Struct28[])((object[])object_0)[int_0];
				if (array != null)
				{
					return array[int_1];
				}
				result = default(Struct28);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 32409583296482094213398", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = default(Struct28);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_1(object object_0, int int_0, int int_1, Struct28 struct28_0)
	{
		try
		{
			if (((object[])object_0)[int_0] == null)
			{
				Struct28[] array = new Struct28[180];
				array[int_1] = struct28_0;
				((object[])object_0)[int_0] = array;
			}
			else
			{
				((Struct28[])((object[])object_0)[int_0])[int_1] = struct28_0;
			}
		}
		catch (OutOfMemoryException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 20324958729856749764398764397", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
