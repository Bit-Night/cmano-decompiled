using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Catfood.Shapefile;
using Command_Core.My;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace Command_Core;

[StandardModule]
public sealed class SeaIceProvider
{
	public enum PolarRegion : byte
	{
		Arctic,
		Antarctic
	}

	private sealed class Class14
	{
		private int int_0;

		private int int_1;

		private ConcurrentDictionary<string, bool> concurrentDictionary_0;

		public Class14()
		{
			int_1 = 10000000;
			concurrentDictionary_0 = new ConcurrentDictionary<string, bool>();
		}

		public bool? method_0(string string_0)
		{
			bool value;
			return (!concurrentDictionary_0.TryGetValue(string_0, out value)) ? ((bool?)null) : new bool?(value);
		}

		public void method_1(string string_0, bool bool_0)
		{
			if (int_0 >= int_1)
			{
				concurrentDictionary_0 = new ConcurrentDictionary<string, bool>();
				int_0 = 0;
			}
			if (concurrentDictionary_0.TryAdd(string_0, bool_0))
			{
				int_0++;
			}
		}

		static Class14()
		{
			Class72.smethod_20();
		}
	}

	private static Class14 class14_0;

	public static DateTime EarliestDataDate;

	private static IcePack[] icePack_0;

	private static double? nullable_0;

	private static double? nullable_1;

	private static LockObject lockObject_0;

	private static string string_0;

	public static IcePack[] CurrentIcePacks
	{
		get
		{
			if (icePack_0 == null)
			{
				icePack_0 = smethod_2(DateTime.Now);
			}
			return icePack_0;
		}
	}

	static SeaIceProvider()
	{
		Class72.smethod_20();
		class14_0 = new Class14();
		EarliestDataDate = new DateTime(1995, 1, 1);
		lockObject_0 = new LockObject();
		string_0 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"dBase IV\"";
	}

	public static void Initialize()
	{
		string[] directories = Directory.GetDirectories(Path.Combine(GameGeneral.GISFolderPath, "SeaIce\\Arctic\\"));
		foreach (string text in directories)
		{
			((ServerComputer)MyProject.Computer).FileSystem.DeleteDirectory(text, (DeleteDirectoryOption)5);
		}
		GetShapefilename(DateTime.Now);
		icePack_0 = smethod_2(DateTime.Now);
	}

	internal static int roundX(double d)
	{
		if (Math.Ceiling(d) - d > 0.5)
		{
			return RadarModel.Floor(d);
		}
		return (int)Math.Ceiling(d);
	}

	internal static bool PointIsUnderIce(double theLon, double theLat)
	{
		bool result = default(bool);
		try
		{
			if (theLat > 0.0)
			{
				double num = theLat;
				double? num2 = nullable_0;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num > num2.GetValueOrDefault())) == true)
				{
					result = true;
					return result;
				}
				num = theLat;
				num2 = nullable_1;
				if ((num2.HasValue ? new bool?(num < num2.GetValueOrDefault()) : ((bool?)null)) != true)
				{
					theLon = Math2.NormalizeLongitude(theLon);
					theLat = Math2.NormalizeLatitude(theLat);
					string uniqueKey = Terrain.GetSingleRasterCell(theLat, theLon).UniqueKey;
					bool? flag = class14_0.method_0(uniqueKey);
					if (!flag.HasValue)
					{
						bool bool_;
						flag = (bool_ = smethod_1(theLat, theLon));
						class14_0.method_1(uniqueKey, bool_);
						result = flag.Value;
						return result;
					}
					result = flag.Value;
					return result;
				}
				result = false;
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101100", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static bool smethod_0(double double_0, double double_1, double double_2, double double_3)
	{
		bool flag = false;
		bool result = default(bool);
		try
		{
			Parallel.ForEach(CurrentIcePacks, [SpecialName] (IcePack thePack, ParallelLoopState loopstate) =>
			{
				if (Math2.LineIntersectsArea_Clipper(double_1, double_0, double_3, double_2, thePack.Area, HaveToCheckAntimeridian: false))
				{
					flag = true;
					loopstate.Stop();
				}
			});
			result = flag;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101101", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static bool smethod_1(double double_0, double double_1)
	{
		bool result = default(bool);
		try
		{
			if (double_0 > 0.0)
			{
				double num = double_0;
				double? num2 = nullable_0;
				if ((num2.HasValue ? new bool?(num > num2.GetValueOrDefault()) : ((bool?)null)) == true)
				{
					result = true;
					return result;
				}
				num = double_0;
				num2 = nullable_1;
				if (((!num2.HasValue) ? ((bool?)null) : new bool?(num < num2.GetValueOrDefault())) == true)
				{
					result = false;
					return result;
				}
				bool flag = false;
				IcePack[] currentIcePacks = CurrentIcePacks;
				for (int i = 0; i < currentIcePacks.Length; i = checked(i + 1))
				{
					if (((FixedGeoPolygon)currentIcePacks[i]).get_PointIsInArea(double_0, double_1, NeedToCheckAntimeridian: false))
					{
						flag = true;
						break;
					}
				}
				result = flag;
				return result;
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101102", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string GetShapefilename(DateTime theDate)
	{
		return Path.Combine(GameGeneral.GISFolderPath, "SeaIce\\Arctic\\nic_autoc2012270n_pl_a.shp");
	}

	private static IcePack[] smethod_2(DateTime dateTime_0)
	{
		List<IcePack> list = new List<IcePack>();
		HashSet<double> hashSet = new HashSet<double>();
		Shapefile shapefile;
		try
		{
			shapefile = new Shapefile(GetShapefilename(DateTime.Now), string_0);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			string_0 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"dBase IV\"";
			shapefile = new Shapefile(GetShapefilename(DateTime.Now), string_0);
			ProjectData.ClearProjectError();
		}
		IcePack[] result;
		try
		{
			foreach (Shape item2 in shapefile)
			{
				if (item2.Type != ShapeType.Polygon)
				{
					continue;
				}
				foreach (PointD[] part in ((ShapePolygon)item2).Parts)
				{
					if (part.Count() <= 30)
					{
						continue;
					}
					List<Geopoint_Struct> list2 = new List<Geopoint_Struct>();
					int num = 0;
					int num2;
					if (part.Count() > 500)
					{
						num = 2;
						num2 = 0;
					}
					else
					{
						num2 = 0;
					}
					int num3 = num2;
					PointD[] array = part;
					for (int i = 0; i < array.Length; i = checked(i + 1))
					{
						PointD pointD = array[i];
						num3++;
						double y = pointD.Y;
						hashSet.Add(y);
						int num4;
						if (num == 0)
						{
							num4 = 0;
						}
						else
						{
							if (num <= 0 || num3 != num)
							{
								continue;
							}
							num4 = 0;
						}
						num3 = num4;
						list2.Add(new Geopoint_Struct(pointD.X, y));
					}
					IcePack item = new IcePack(list2);
					list.Add(item);
				}
			}
			nullable_0 = hashSet.Max();
			nullable_1 = hashSet.Min();
			result = list.ToArray();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101103", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (!Debugger.IsAttached)
			{
				num5 = 0;
			}
			else
			{
				Debugger.Break();
				num5 = 0;
			}
			result = new IcePack[num5];
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
