using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using CSMaterial;
using Microsoft.Extensions.Caching.Memory;
using ServiceStack.Text;

namespace SRTM;

public sealed class SRTMData : ISRTMData
{
	public delegate bool GetMissingCellDelegate(string path, string name);

	private ISRTMSource isrtmsource_0;

	private bool bool_0 = true;

	private SRTMTemporaryFileSaver srtmtemporaryFileSaver_0;

	private TwoStepCache twoStepCache_0;

	private readonly MemoryCacheEntryOptions memoryCacheEntryOptions_0 = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(15.0));

	[CompilerGenerated]
	private GetMissingCellDelegate getMissingCellDelegate_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private List<ISRTMDataCell> cybywuoVaJL;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private string string_1;

	private static ConcurrentDictionary<string, bool> concurrentDictionary_0;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	[ThreadStatic]
	private static string string_2;

	public GetMissingCellDelegate GetMissingCell
	{
		[CompilerGenerated]
		get
		{
			return getMissingCellDelegate_0;
		}
		[CompilerGenerated]
		set
		{
			getMissingCellDelegate_0 = value;
		}
	}

	public string DataDirectory
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public SRTMData(string dataDirectory, ISRTMSource source)
	{
		if (!Directory.Exists(dataDirectory))
		{
			throw new DirectoryNotFoundException(dataDirectory);
		}
		if (source != null)
		{
			isrtmsource_0 = source;
			GetMissingCell = isrtmsource_0.GetMissingCell;
		}
		DataDirectory = dataDirectory;
		method_1(new List<ISRTMDataCell>());
		method_5(Path.Combine(DataDirectory, "SRTM3.7z"));
		method_3(FileExistsNative.FileExistsFast(method_4()));
		if (bool_0)
		{
			srtmtemporaryFileSaver_0 = new SRTMTemporaryFileSaver(DataDirectory);
		}
		twoStepCache_0 = new TwoStepCache();
	}

	public void ClearCache()
	{
		if (twoStepCache_0 != null)
		{
			twoStepCache_0.ClearCache();
		}
	}

	public void DisposeResources()
	{
		if (bool_0)
		{
			if (srtmtemporaryFileSaver_0 != null)
			{
				srtmtemporaryFileSaver_0.ShutDown();
			}
			string[] files = Directory.GetFiles(DataDirectory, "*.hgt", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				File.Delete(files[i]);
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private List<ISRTMDataCell> method_0()
	{
		return cybywuoVaJL;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(List<ISRTMDataCell> list_0)
	{
		cybywuoVaJL = list_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_2()
	{
		return bool_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_3(bool bool_2)
	{
		bool_1 = bool_2;
	}

	[SpecialName]
	[CompilerGenerated]
	private string method_4()
	{
		return string_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_5(string string_3)
	{
		string_1 = string_3;
	}

	public void Unload()
	{
		method_0().Clear();
	}

	public int? GetElevation(double latitude, double longitude)
	{
		try
		{
			if (longitude >= 180.0)
			{
				longitude = -180.0;
			}
			if (latitude == 90.0)
			{
				latitude = 89.0;
			}
			return GetDataCell(latitude, longitude).GetElevation(latitude, longitude);
		}
		catch (Exception)
		{
			try
			{
				return GetDataCell(latitude, longitude).GetElevation(latitude, longitude);
			}
			catch (Exception)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public double? GetElevationBilinear(double latitude, double longitude)
	{
		if (longitude == 180.0)
		{
			longitude = -180.0;
		}
		return GetDataCell(latitude, longitude).GetElevationBilinear(latitude, longitude);
	}

	public int GetCellLatitude(double latitude)
	{
		int num = (int)Math.Floor(Math.Abs(latitude));
		if (latitude < 0.0)
		{
			num *= -1;
			if ((double)num != latitude)
			{
				num--;
			}
		}
		return num;
	}

	public int GetCellLongitude(double longitude)
	{
		int num = (int)Math.Floor(Math.Abs(longitude));
		if (longitude >= 0.0)
		{
			if (longitude == 180.0)
			{
				num = -180;
			}
		}
		else
		{
			num *= -1;
			if ((double)num != longitude)
			{
				num--;
			}
		}
		return num;
	}

	public ISRTMDataCell GetDataCell(double latitude, double longitude)
	{
		bool flag = false;
		int cellLatitude = GetCellLatitude(latitude);
		int cellLongitude = GetCellLongitude(longitude);
		int key = cellLatitude + 180;
		MemoryCache orCreateCache = twoStepCache_0.GetOrCreateCache(key);
		if (!orCreateCache.TryGetValue<ISRTMDataCell>(cellLongitude, out ISRTMDataCell value))
		{
			if (stringBuilder_0 == null)
			{
				stringBuilder_0 = StringBuilderCache.Allocate();
			}
			stringBuilder_0.Clear();
			stringBuilder_0.Append((cellLatitude < 0) ? "S" : "N");
			stringBuilder_0.Append(Math.Abs(cellLatitude).ToString("D2"));
			stringBuilder_0.Append((cellLongitude < 0) ? "W" : "E");
			stringBuilder_0.Append(Math.Abs(cellLongitude).ToString("D3"));
			string_2 = stringBuilder_0.ToString();
			if (method_2())
			{
				value = new SRTMDataCell(method_4(), string_2 + ".hgt");
			}
			else
			{
				string text = Path.Combine(DataDirectory, string_2 + ".hgt");
				string text2 = Path.Combine(DataDirectory, string_2 + ".hgt.zip");
				string text3 = Path.Combine(DataDirectory, string_2 + ".txt");
				int num = -1;
				if (!concurrentDictionary_0.ContainsKey(text) && !FileExistsNative.FileExistsFast(text))
				{
					if (FileExistsNative.FileExistsFast(text2))
					{
						value = new SRTMDataCell(text2);
						flag = true;
					}
					else
					{
						if (num < 0)
						{
							File.WriteAllText(text3, "1");
							return GetDataCell(latitude, longitude);
						}
						if (num < 3)
						{
							File.WriteAllText(text3, (num + 1).ToString());
							return GetDataCell(latitude, longitude);
						}
						value = new EmptySRTMDataCell(text3);
					}
				}
				else
				{
					value = new SRTMDataCell(text);
					concurrentDictionary_0.TryAdd(text, value: true);
				}
			}
			if (orCreateCache.Count > 1000)
			{
				orCreateCache.Compact(0.5);
			}
			try
			{
				orCreateCache.Set(cellLongitude, value, memoryCacheEntryOptions_0.SetSize(1L).SetSlidingExpiration(new TimeSpan(0, 0, 60)));
			}
			catch (OutOfMemoryException)
			{
				orCreateCache.Compact(1.0);
			}
			if (bool_0 && flag)
			{
				string fileName = Path.Combine(DataDirectory, string_2 + ".hgt");
				srtmtemporaryFileSaver_0.Save(fileName, value);
			}
			return value;
		}
		return value;
	}

	static SRTMData()
	{
		Class72.smethod_20();
		concurrentDictionary_0 = new ConcurrentDictionary<string, bool>();
	}
}
