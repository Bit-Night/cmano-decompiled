using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Command_Core;
using CSMaterial;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class UnitImageCaching
{
	[CompilerGenerated]
	internal sealed class _Closure$__17-0
	{
		public HashSet<string> $VB$Local_PathsList;

		public _Closure$__17-0(_Closure$__17-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_PathsList = arg0.$VB$Local_PathsList;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			foreach (string item in $VB$Local_PathsList)
			{
				if (!FileExistsNative.FileExistsFast(item))
				{
					try
					{
						FetchImageFromRemoteServers(item);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
		}

		static _Closure$__17-0()
		{
			Class72.smethod_20();
		}
	}

	private static string[] string_0;

	private static Dictionary<string, BitmapImage> dictionary_0;

	private static HashSet<string> hashSet_0;

	private static EventWaitHandle eventWaitHandle_0;

	private static ConcurrentQueue<string> concurrentQueue_0;

	private static DBOps.DBFileCheckResult dbfileCheckResult_0;

	static UnitImageCaching()
	{
		Class72.smethod_20();
		dictionary_0 = new Dictionary<string, BitmapImage>();
		hashSet_0 = new HashSet<string>();
		eventWaitHandle_0 = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		concurrentQueue_0 = new ConcurrentQueue<string>();
	}

	public static BitmapImage getCachedBitmapImage(string ImageFileString)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (!dictionary_0.ContainsKey(ImageFileString))
		{
			if (!Directory.Exists(Path.GetDirectoryName(ImageFileString)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(ImageFileString));
			}
			if (FileExistsNative.FileExistsFast(ImageFileString))
			{
				BitmapImage result = default(BitmapImage);
				try
				{
					BitmapImage val = new BitmapImage(new Uri(ImageFileString));
					dictionary_0[ImageFileString] = val;
					result = val;
					return result;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				return result;
			}
			FetchImageFromRemoteServers(ImageFileString);
			return null;
		}
		return dictionary_0[ImageFileString];
	}

	public static void FetchImageFromRemoteServers(string theImageFilePath)
	{
		if (SimConfiguration.DefaultGamePreferences.AllowInGameDownloads)
		{
			concurrentQueue_0.Enqueue(theImageFilePath);
			eventWaitHandle_0.Set();
		}
	}

	public static void Initialize()
	{
		string_0 = SimConfiguration.GetRemoteImageServers();
	}

	public static string getMainImageFileString(ActiveUnit theAU, bool UseVirtualFolderMapping = false)
	{
		string unitPlatformString = getUnitPlatformString(theAU);
		return getPlatformImageFileString(smethod_0(theAU.ParentScen.DBUsed), unitPlatformString, theAU.DBID, 0, UseVirtualFolderMapping);
	}

	public static List<string> getThumbnailImageFileStrings(ActiveUnit theAU, bool UseVirtualFolderMapping = false)
	{
		string unitPlatformString = getUnitPlatformString(theAU);
		string dBString = smethod_0(theAU.ParentScen.DBUsed);
		List<string> list = new List<string>();
		int num = 1;
		do
		{
			list.Add(getPlatformImageFileString(dBString, unitPlatformString, theAU.DBID, num, UseVirtualFolderMapping));
			num++;
		}
		while (num <= 6);
		return list;
	}

	public static string GetSensorMainImageFileString(string DBUsed, int theDBID, bool UseVirtualFolderMapping = false)
	{
		string platformString = "Sensor";
		return getPlatformImageFileString(smethod_0(DBUsed), platformString, theDBID, 0, UseVirtualFolderMapping);
	}

	public static List<string> getSensorThumbnailImageFileStrings(string DBUsed, int theDBID, bool UseVirtualFolderMapping = false)
	{
		string platformString = "Sensor";
		string dBString = smethod_0(DBUsed);
		List<string> list = new List<string>();
		int num = 1;
		do
		{
			list.Add(getPlatformImageFileString(dBString, platformString, theDBID, num, UseVirtualFolderMapping));
			num++;
		}
		while (num <= 6);
		return list;
	}

	public static string getUnitPlatformString(ActiveUnit theAU)
	{
		string result = string.Empty;
		if (!theAU.IsAircraft)
		{
			if (theAU.IsShip)
			{
				result = "Ship";
			}
			else if (theAU.IsSubmarine)
			{
				result = "Submarine";
			}
			else if (!theAU.IsFacility)
			{
				if (!theAU.IsMobileGroundUnit)
				{
					if (theAU.IsSatellite)
					{
						result = "Satellite";
					}
					else if (theAU.IsWeapon)
					{
						result = "Weapon";
					}
					else
					{
						if (theAU.IsGroup)
						{
							theAU = ((Group)theAU).GroupLead;
							return getUnitPlatformString(theAU);
						}
						if (theAU.UnitType == GlobalVariables.ActiveUnitType.AggregateGroundUnit)
						{
							result = "Aggregate";
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				else
				{
					result = "GroundUnit";
				}
			}
			else
			{
				result = "Facility";
			}
		}
		else
		{
			result = "Aircraft";
		}
		return result;
	}

	public static string smethod_0(string DBUsed)
	{
		string result = "";
		DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(DBUsed, ref dbfileCheckResult_0, CheckLocalFileExists: false, CheckForTampering: false);
		if (dBRecordByHash != null)
		{
			switch (dBRecordByHash.DBID)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case 1:
				result = "DB3000";
				break;
			case 2:
				result = "CWDB";
				break;
			case 3:
				result = "WW2DB";
				break;
			}
		}
		return result;
	}

	public static string getPlatformImageFileString(string DBString, string PlatformString, int theDBID, int theThumbIndex = 0, bool UseVirtualFolderMapping = false)
	{
		string text = Path.Combine(GameGeneral.DBFolderPath, "Images", DBString);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string text2 = ((theThumbIndex != 0) ? (PlatformString + "_" + Conversions.ToString(theDBID) + "_t" + Conversions.ToString(theThumbIndex)) : (PlatformString + "_" + Conversions.ToString(theDBID)));
		string text3 = text2 + ".webp";
		string[] array = new string[4] { ".webp", ".png", ".jpg", ".jpeg" };
		foreach (string text4 in array)
		{
			string text5 = text2 + text4;
			if (FileExistsNative.FileExistsFast(Path.Combine(text, text5)))
			{
				text3 = text5;
				break;
			}
		}
		if (UseVirtualFolderMapping)
		{
			return "https://dbimages.invalid/" + DBString + "/" + text3;
		}
		return Path.Combine(text, text3);
	}

	public static void FetchImagesForAllUnitsInThisScenario(Scenario theScen)
	{
		_Closure$__17-0 arg = default(_Closure$__17-0);
		_Closure$__17-0 CS$<>8__locals4 = new _Closure$__17-0(arg);
		List<ActiveUnit> list = theScen.ActiveUnits.Values.ToList();
		CS$<>8__locals4.$VB$Local_PathsList = new HashSet<string>();
		foreach (ActiveUnit item in list)
		{
			if (!item.IsGroup)
			{
				CS$<>8__locals4.$VB$Local_PathsList.Add(getMainImageFileString(item));
			}
		}
		foreach (ActiveUnit item2 in list)
		{
			if (item2.IsGroup)
			{
				continue;
			}
			List<string> thumbnailImageFileStrings = getThumbnailImageFileStrings(item2);
			foreach (string item3 in thumbnailImageFileStrings)
			{
				CS$<>8__locals4.$VB$Local_PathsList.Add(item3);
			}
		}
		theScen = null;
		list = null;
		Task.Factory.StartNew([SpecialName] () =>
		{
			foreach (string item4 in CS$<>8__locals4.$VB$Local_PathsList)
			{
				if (!FileExistsNative.FileExistsFast(item4))
				{
					try
					{
						FetchImageFromRemoteServers(item4);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
		});
	}

	public static void DownloadDBImages()
	{
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		while (true)
		{
			eventWaitHandle_0.WaitOne();
			if (!InternetConnectivityCheck.InternetConnectionAvailable)
			{
				continue;
			}
			if (!Directory.Exists(GameGeneral.TempPath))
			{
				Directory.CreateDirectory(GameGeneral.TempPath);
			}
			while (concurrentQueue_0.Count > 0)
			{
				try
				{
					string result = string.Empty;
					concurrentQueue_0.TryDequeue(out result);
					if (hashSet_0.Contains(result))
					{
						continue;
					}
					string fileName = Path.GetFileName(result);
					string text = GameGeneral.TempPath + "\\" + fileName;
					if (File.Exists(text))
					{
						try
						{
							File.Delete(text);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							_ = Debugger.IsAttached;
							ProjectData.ClearProjectError();
						}
					}
					int num;
					string[] array;
					if (string_0 == null)
					{
						num = 1;
					}
					else
					{
						if (string_0.Length > 0)
						{
							array = string_0;
							goto IL_00cb;
						}
						num = 1;
					}
					string[] array2 = new string[num];
					array2[0] = "http://warfaresims.slitherine.com/DBImages";
					array = array2;
					goto IL_00cb;
					IL_00cb:
					string fileName2 = Path.GetFileName(Path.GetDirectoryName(result));
					string fileName3 = Path.GetFileName(result);
					bool flag = false;
					string[] array3 = array;
					foreach (string text2 in array3)
					{
						Uri uri = new Uri(text2 + "/" + fileName2 + "/" + fileName3);
						try
						{
							FileInfo fileInfo = null;
							if (FileExistsNative.FileExistsFast(fileName2))
							{
								fileInfo = new FileInfo(fileName2);
								if (fileInfo.Length == 0L)
								{
									try
									{
										File.Delete(fileName2);
									}
									catch (Exception projectError2)
									{
										ProjectData.SetProjectError(projectError2);
										_ = Debugger.IsAttached;
										ProjectData.ClearProjectError();
									}
								}
							}
							if (!HTTPHelper.DownloadFile(uri.ToString(), text))
							{
								continue;
							}
							FileInfo fileInfo2 = new FileInfo(text);
							if (fileInfo2.Length == 0L)
							{
								try
								{
									File.Delete(text);
									return;
								}
								catch (Exception projectError3)
								{
									ProjectData.SetProjectError(projectError3);
									_ = Debugger.IsAttached;
									ProjectData.ClearProjectError();
									return;
								}
							}
							bool flag2 = true;
							try
							{
								new BitmapImage(new Uri(text));
							}
							catch (Exception projectError4)
							{
								ProjectData.SetProjectError(projectError4);
								flag2 = false;
								ProjectData.ClearProjectError();
							}
							if (!flag2)
							{
								try
								{
									File.Delete(text);
								}
								catch (Exception projectError5)
								{
									ProjectData.SetProjectError(projectError5);
									_ = Debugger.IsAttached;
									ProjectData.ClearProjectError();
								}
								continue;
							}
							try
							{
								if (!FileExistsNative.FileExistsFast(result))
								{
									File.Copy(text, result, overwrite: true);
								}
								else if (fileInfo != null && fileInfo2.Length != fileInfo.Length)
								{
									File.Copy(text, result, overwrite: true);
								}
							}
							catch (Exception projectError6)
							{
								ProjectData.SetProjectError(projectError6);
								_ = Debugger.IsAttached;
								ProjectData.ClearProjectError();
							}
							flag = true;
							break;
						}
						catch (WebException projectError7)
						{
							ProjectData.SetProjectError((Exception)projectError7);
							try
							{
								File.Delete(text);
							}
							catch (Exception projectError8)
							{
								ProjectData.SetProjectError(projectError8);
								_ = Debugger.IsAttached;
								ProjectData.ClearProjectError();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!flag)
					{
						hashSet_0.Add(result);
					}
				}
				catch (Exception projectError9)
				{
					ProjectData.SetProjectError(projectError9);
					ProjectData.ClearProjectError();
				}
			}
		}
	}
}
