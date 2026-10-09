using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Command_Core.My;
using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using CoordinateSharp;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using ServiceStack.Text;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Misc
{
	public enum PostureStance : byte
	{
		Neutral,
		Friendly,
		Unfriendly,
		Hostile,
		Unknown
	}

	public enum DiskType : byte
	{
		Undefined,
		HDD,
		SSD,
		SCM
	}

	public enum ExtendPhase : byte
	{
		FinalApproach,
		LiningUp,
		Extending,
		Standard
	}

	public enum GroupingLogic
	{
		SplitByType,
		MixedGroup
	}

	public enum TurnDirection
	{
		TurnLeft = 1,
		TurnRight = 2,
		TurnPort = 1,
		TurnStarboard = 2
	}

	[CompilerGenerated]
	internal sealed class _Closure$__148-0
	{
		public int $VB$Local_theInt;

		public _Closure$__148-0(_Closure$__148-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theInt = arg0.$VB$Local_theInt;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(ActiveUnit AC)
		{
			return ((Aircraft)AC).LoadoutDBID == $VB$Local_theInt;
		}

		static _Closure$__148-0()
		{
			Class72.smethod_20();
		}
	}

	public const float METERS_TO_FEET = 3.28084f;

	public const float FEET_TO_METERS = 0.3048f;

	public const int PeriscopeRadarSignature = -30;

	public const int PeriscopeVisualSignature = 2;

	public const int PeriscopeInfraredSignature = 2;

	public const int PeriscopeDepth_m = -20;

	public const int SnorkelRadarSignature = -20;

	public const int SnorkelVisualSignature = 2;

	public const int SnorkelInfraredSignature = 2;

	public const int SurfacedDepth_m = -5;

	public const float MaxTargetSpeedOverrideModifier = 1.2f;

	public const float MinTargetSpeedOverrideModifier = 0.8f;

	public static double AngularDistance_5nm;

	public static string LastBarkText;

	public const float float_0 = -10000f;

	private static readonly float[] float_1;

	private static readonly bool[] bool_0;

	static Misc()
	{
		Class72.smethod_20();
		LastBarkText = "";
		float_1 = new float[8] { 1f, 10f, 100f, 1000f, 10000f, 100000f, 1000000f, 10000000f };
		bool_0 = smethod_2();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ParseBool(string s)
	{
		return s.Length switch
		{
			4 => string.Equals(s, "True", StringComparison.OrdinalIgnoreCase), 
			1 => object.Equals(s, 1), 
			_ => false, 
		};
	}

	public static void SyncLists<T>(List<T> source, ObservableCollection<T> target)
	{
		for (int i = target.Count - 1; i >= 0; i += -1)
		{
			if (!source.Contains(target[i]))
			{
				target.RemoveAt(i);
			}
		}
		foreach (T item in source)
		{
			if (!target.Contains(item))
			{
				target.Add(item);
			}
		}
	}

	public static bool HasElementChildren(this XmlNode theNode)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		foreach (XmlNode childNode in theNode.ChildNodes)
		{
			if ((int)childNode.NodeType == 1)
			{
				return true;
			}
		}
		return false;
	}

	public static Group GetByName(this TList<Group> theList, string theName)
	{
		return (from theG in theList
			select (theG) into theG
			where Operators.CompareString(theG.Name, theName, false) == 0
			select theG).ElementAtOrDefault(0);
	}

	public static bool ContainsByName(this TList<Group> theList, string theName)
	{
		return (from theG in theList
			select (theG) into theG
			where Operators.CompareString(theG.Name, theName, false) == 0
			select theG).Count() > 0;
	}

	internal static float AddSingleToSignificantDigit(float val1, float val2, int sigDigits)
	{
		float num = float_1[sigDigits];
		return (float)(Math.Round((val1 + val2) * num) / (double)num);
	}

	internal static float SubtractSingleToSignificantDigit(float val1, float val2, int sigDigits)
	{
		float num = float_1[sigDigits];
		return (float)(Math.Round((val1 - val2) * num) / (double)num);
	}

	public static GlobalVariables.BooleanObject ToBooleanObject(this bool theBool)
	{
		if (theBool)
		{
			return GlobalVariables.ObjectTrue;
		}
		return GlobalVariables.ObjectFalse;
	}

	public static GlobalVariables.BooleanObject ToBooleanObject(this bool? theBool)
	{
		if (!theBool.HasValue)
		{
			return null;
		}
		if (!theBool.Value)
		{
			return GlobalVariables.ObjectFalse;
		}
		return GlobalVariables.ObjectTrue;
	}

	internal static List<FiringProposal> ToList_NoSnapshot(this ConcurrentQueue<FiringProposal> theQueue)
	{
		List<FiringProposal> list = new List<FiringProposal>();
		FiringProposal result;
		while (theQueue.TryDequeue(out result))
		{
			list.Add(result);
		}
		return list;
	}

	internal static string RemoveIllegalFilepathCharacters(string SourceString, string ReplaceWith = "")
	{
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		string text = SourceString;
		for (int i = 0; i < text.Length; i = checked(i + 1))
		{
			char c = text[i];
			char[] array = invalidFileNameChars;
			foreach (char c2 in array)
			{
				if (Operators.CompareString(c2.ToString(), c.ToString(), false) == 0)
				{
					SourceString = SourceString.Replace(Conversions.ToString(c), ReplaceWith);
				}
			}
		}
		return SourceString;
	}

	internal static List<T> GetClone<T>(this List<T> source)
	{
		return source?.GetRange(0, source.Count);
	}

	internal static T[] ToArray_NoLINQ<T>(this TList<T> source)
	{
		if (source == null)
		{
			return null;
		}
		int count = source.Count;
		T[] array = new T[count - 1 + 1];
		try
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = source[i];
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				array[j] = source[j];
			}
			ProjectData.ClearProjectError();
		}
		return array;
	}

	public static T[] ToArray_NoLINQ<T>(this List<T> source)
	{
		if (source.Count == 0)
		{
			return new T[0];
		}
		int count = source.Count;
		T[] array = new T[count - 1 + 1];
		int num = count - 1;
		for (int i = 0; i <= num; i++)
		{
			array[i] = source[i];
		}
		return array;
	}

	public static void Sort<TSource, TKey>(this ObservableCollection<TSource> collection, Func<TSource, TKey> keySelector, bool SortByDescending)
	{
		List<TSource> list = ((!SortByDescending) ? new List<TSource>(collection.OrderBy(keySelector)) : new List<TSource>(collection.OrderByDescending(keySelector)));
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			object obj = collection[i];
			object obj2 = list[i];
			if (obj != obj2)
			{
				int num2 = collection.IndexOf(list[i]);
				if (num2 != i)
				{
					collection.Move(num2, i);
				}
			}
		}
	}

	public static Color GetColorFromInteger(int value)
	{
		int int_ = Math.Abs(value) * 137 % 360;
		double double_ = 0.8;
		double double_2 = 0.5;
		return smethod_0(int_, double_, double_2);
	}

	private static Color smethod_0(int int_0, double double_0, double double_1)
	{
		double num = (1.0 - Math.Abs(2.0 * double_1 - 1.0)) * double_0;
		double num2 = num * (1.0 - Math.Abs((double)int_0 / 60.0 % 2.0 - 1.0));
		double num3 = double_1 - num / 2.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		if (!(int_0 >= 0 && int_0 < 60))
		{
			if (!(int_0 >= 60 && int_0 < 120))
			{
				if (!(int_0 >= 120 && int_0 < 180))
				{
					if (!(int_0 >= 180 && int_0 < 240))
					{
						if (int_0 >= 240 && int_0 < 300)
						{
							num4 = num2;
							num5 = 0.0;
							num6 = num;
						}
						else if (int_0 >= 300 && int_0 < 360)
						{
							num4 = num;
							num5 = 0.0;
							num6 = num2;
						}
					}
					else
					{
						num4 = 0.0;
						num5 = num2;
						num6 = num;
					}
				}
				else
				{
					num4 = 0.0;
					num5 = num;
					num6 = num2;
				}
			}
			else
			{
				num4 = num2;
				num5 = num;
				num6 = 0.0;
			}
		}
		else
		{
			num4 = num;
			num5 = num2;
			num6 = 0.0;
		}
		int red = (int)Math.Round((num4 + num3) * 255.0);
		int green = (int)Math.Round((num5 + num3) * 255.0);
		int blue = (int)Math.Round((num6 + num3) * 255.0);
		return Color.FromArgb(255, red, green, blue);
	}

	internal static DiskType DetermineDiskType(int theDiskNumber)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		ManagementScope val = new ManagementScope("\\\\.\\root\\microsoft\\windows\\storage");
		ManagementObjectSearcher val2 = new ManagementObjectSearcher("SELECT * FROM MSFT_PhysicalDisk");
		DiskType result;
		try
		{
			val.Connect();
			val2.Scope = val;
			ManagementObjectCollection val3 = val2.Get();
			ManagementObjectEnumerator enumerator = default(ManagementObjectEnumerator);
			DiskType diskType = default(DiskType);
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ManagementObject val4 = (ManagementObject)enumerator.Current;
					if (Conversions.ToInteger(((ManagementBaseObject)val4)["DeviceId"]) == theDiskNumber)
					{
						int num;
						switch (Convert.ToInt16(RuntimeHelpers.GetObjectValue(((ManagementBaseObject)val4)["MediaType"])))
						{
						default:
							num = 0;
							goto IL_0098;
						case 1:
							diskType = DiskType.Undefined;
							break;
						case 2:
							num = 0;
							goto IL_0098;
						case 3:
							diskType = DiskType.HDD;
							break;
						case 4:
							diskType = DiskType.SSD;
							break;
						case 5:
							{
								diskType = DiskType.SCM;
								break;
							}
							IL_0098:
							diskType = (DiskType)num;
							break;
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			((Component)(object)val2).Dispose();
			result = diskType;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = (DiskType)num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static string GetDiskIndex(string driveLetter)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		driveLetter = driveLetter.TrimEnd(new char[1] { '\\' });
		ManagementScope val = new ManagementScope("\\root\\cimv2");
		ManagementObjectCollection val2 = new ManagementObjectSearcher(val, new ObjectQuery("select * from Win32_DiskDrive")).Get();
		string result;
		try
		{
			ManagementObjectEnumerator enumerator = default(ManagementObjectEnumerator);
			try
			{
				enumerator = val2.GetEnumerator();
				ManagementObjectEnumerator enumerator2 = default(ManagementObjectEnumerator);
				ManagementObjectEnumerator enumerator3 = default(ManagementObjectEnumerator);
				while (enumerator.MoveNext())
				{
					ManagementObject val3 = (ManagementObject)enumerator.Current;
					ManagementObjectCollection val4 = new ManagementObjectSearcher(val, new ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + Conversions.ToString(((ManagementBaseObject)val3)["DeviceID"]) + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition")).Get();
					try
					{
						enumerator2 = val4.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ManagementObject val5 = (ManagementObject)enumerator2.Current;
							ManagementObjectCollection val6 = new ManagementObjectSearcher(val, new ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + Conversions.ToString(((ManagementBaseObject)val5)["DeviceID"]) + "'} WHERE AssocClass = Win32_LogicalDiskToPartition")).Get();
							try
							{
								enumerator3 = val6.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									if (Operators.CompareString(enumerator3.Current["DeviceId"].ToString(), driveLetter, false) != 0)
									{
										continue;
									}
									result = ((ManagementBaseObject)val5)["DiskIndex"].ToString();
									goto end_IL_0037;
								}
							}
							finally
							{
								((IDisposable)enumerator3)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			result = null;
			end_IL_0037:;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string LatitudeToEnglish(double Lat)
	{
		string text;
		if (Lat > 0.0)
		{
			text = "N";
		}
		else
		{
			text = "S";
			Lat = 0.0 - Lat;
		}
		return text + MathFunctions.MinSecToString(MathFunctions.DegToMinSec(Math.Round(Lat, 4)));
	}

	public static string LongitudeToEnglish(double Lon)
	{
		string text;
		if (Lon <= 0.0)
		{
			text = "W";
			Lon = 0.0 - Lon;
		}
		else
		{
			text = "E";
		}
		return text + MathFunctions.MinSecToString(MathFunctions.DegToMinSec(Math.Round(Lon, 4)));
	}

	public static string ReplaceIllegalCharacters(string strIn, string strChar)
	{
		string pattern = "[~\"#%&*:<>?{|}/\\\\[\\]\r\n]";
		return Regex.Replace(strIn, pattern, strChar);
	}

	public static Alertlevels GetSelectedIntermittentEmissionConfig_ByString(string PresetAlertID)
	{
		PresetAlertID = PresetAlertID.ToLower();
		return PresetAlertID switch
		{
			"custom" => Alertlevels.Custom, 
			"red" => Alertlevels.Red, 
			"orange" => Alertlevels.Orange, 
			"yellow" => Alertlevels.Yellow, 
			"blue" => Alertlevels.Blue, 
			"green" => Alertlevels.Green, 
			_ => Alertlevels.Unknown, 
		};
	}

	public static ActiveUnit GetActiveUnitByNameOrID(string NameOrID, Scenario ScenarioContext)
	{
		ActiveUnit value = null;
		ScenarioContext.ActiveUnits.TryGetValue(NameOrID, out value);
		if (value == null)
		{
			foreach (ActiveUnit value2 in ScenarioContext.ActiveUnits.Values)
			{
				if (value2 != null && string.Equals(value2.Name, NameOrID, StringComparison.OrdinalIgnoreCase))
				{
					value = value2;
					break;
				}
			}
		}
		return value;
	}

	public static Side GetSideByNameOrID(string NameOrID, Scenario ScenarioContext)
	{
		return (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, NameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, NameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
	}

	public static Mission GetMissionByNameOrID(string SideNameOrID, string NameOrID, Scenario ScenarioContext)
	{
		Side sideByNameOrID = GetSideByNameOrID(SideNameOrID, ScenarioContext);
		if (sideByNameOrID != null)
		{
			foreach (Mission mission in sideByNameOrID.Missions)
			{
				if (Operators.CompareString(mission.Name, NameOrID, false) == 0 || Operators.CompareString(mission.ObjectID, NameOrID, false) == 0)
				{
					return mission;
				}
			}
		}
		return null;
	}

	internal static bool Dir_WritePermission(string DirPath)
	{
		if (!((ServerComputer)MyProject.Computer).FileSystem.DirectoryExists(DirPath))
		{
			return false;
		}
		bool flag = false;
		bool flag2 = false;
		DirectorySecurity accessControl = Directory.GetAccessControl(DirPath);
		if (accessControl == null)
		{
			return false;
		}
		AuthorizationRuleCollection accessRules = accessControl.GetAccessRules(includeExplicit: true, includeInherited: true, typeof(SecurityIdentifier));
		if (accessRules == null)
		{
			return false;
		}
		foreach (FileSystemAccessRule item in accessRules)
		{
			if ((FileSystemRights.Write & item.FileSystemRights) == FileSystemRights.Write)
			{
				if (item.AccessControlType == AccessControlType.Allow)
				{
					flag = true;
				}
				if (item.AccessControlType == AccessControlType.Deny)
				{
					flag2 = true;
				}
			}
		}
		int result;
		if (!flag)
		{
			result = 0;
		}
		else
		{
			if (!flag2)
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	internal static bool CanBeCastToInteger(double theNumber)
	{
		bool result;
		try
		{
			_ = (int)Math.Round(theNumber);
			result = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200090", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static bool IsDirectoryEmpty(string path)
	{
		return !Directory.EnumerateFileSystemEntries(path).Any();
	}

	internal static string BearingToString(float bearing)
	{
		string text = string.Format("{0:0.0}", bearing, 2);
		if (Operators.CompareString(text, "360.0", false) == 0)
		{
			text = "0.0";
		}
		else if (Operators.CompareString(text, "360", false) == 0)
		{
			text = "360";
		}
		return text;
	}

	internal static string GeoreferenceFileForThisImageFile(string theImageFile)
	{
		string extension = Path.GetExtension(theImageFile);
		extension = ((extension.Length != 4) ? (extension + "w") : (Conversions.ToString(extension[0]) + Conversions.ToString(extension[1]) + Conversions.ToString(extension[extension.Length - 1]) + "w"));
		string text = Path.ChangeExtension(theImageFile, extension);
		if (FileExistsNative.FileExistsFast(text))
		{
			string text2 = File.ReadAllText(text);
			text2 = text2.Replace(",", ".");
			File.WriteAllText(text, text2);
			return text;
		}
		return null;
	}

	public static void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (directoryInfo.Exists)
		{
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string destFileName = Path.Combine(destDirName, fileInfo.Name);
				fileInfo.CopyTo(destFileName, overwrite: true);
			}
			if (copySubDirs)
			{
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
					CopyDirectory(directoryInfo2.FullName, destDirName2, copySubDirs);
				}
			}
			return;
		}
		throw new DirectoryNotFoundException(Convert.ToString("Source directory does not exist or could not be found: ") + sourceDirName);
	}

	public static void DeleteEverythingInDirectory(string theDirectory)
	{
		if (Directory.Exists(theDirectory))
		{
			foreach (string item in Directory.EnumerateDirectories(theDirectory))
			{
				Directory.Delete(item, recursive: true);
			}
			string[] files = Directory.GetFiles(theDirectory);
			foreach (string text in files)
			{
				if (!text.EndsWith("\\instance"))
				{
					try
					{
						File.Delete(text);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200574: Could not delete file " + text, ex2.Message);
						_ = Debugger.IsAttached;
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		else
		{
			Directory.CreateDirectory(theDirectory);
		}
	}

	public static int LevenshteinDistance(string s, string t)
	{
		int length = s.Length;
		int length2 = t.Length;
		int[,] array = new int[length + 1, length2 + 1];
		if (length == 0)
		{
			return length2;
		}
		if (length2 == 0)
		{
			return length;
		}
		int location = 0;
		while (location <= length)
		{
			array[location, 0] = Math.Max(Interlocked.Increment(ref location), location - 1);
		}
		int location2 = 0;
		while (location2 <= length2)
		{
			array[0, location2] = Math.Max(Interlocked.Increment(ref location2), location2 - 1);
		}
		int num = length;
		for (int i = 1; i <= num; i++)
		{
			int num2 = length2;
			for (int j = 1; j <= num2; j++)
			{
				int num3 = ((t[j - 1] != s[i - 1]) ? 1 : 0);
				array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1, array[i, j - 1] + 1), array[i - 1, j - 1] + num3);
			}
		}
		return array[length, length2];
	}

	internal static string smethod_1(string source)
	{
		char[] array = new char[source.Length - 1 + 1];
		int num = 0;
		bool flag = false;
		int num2 = source.Length - 1;
		for (int i = 0; i <= num2; i++)
		{
			char c = source[i];
			switch (c)
			{
			case '<':
				flag = true;
				continue;
			case '>':
				flag = false;
				continue;
			}
			if (!flag)
			{
				array[num] = c;
				num++;
			}
		}
		return new string(array, 0, num).Replace("&nbsp;", " ");
	}

	public static void CopyDirectoryOverwriteIfDifferent(string sourceDirName, string destDirName, bool copySubDirs)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (!directoryInfo.Exists)
		{
			throw new DirectoryNotFoundException(Convert.ToString("Source directory does not exist or could not be found: ") + sourceDirName);
		}
		if (!Directory.Exists(destDirName))
		{
			Directory.CreateDirectory(destDirName);
		}
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			string text = Path.Combine(destDirName, fileInfo.Name);
			if (!FileExistsNative.FileExistsFast(text))
			{
				fileInfo.CopyTo(text, overwrite: true);
				continue;
			}
			FileInfo fileInfo2 = new FileInfo(text);
			if (DateTime.Compare(fileInfo2.LastWriteTimeUtc, fileInfo.LastWriteTimeUtc) != 0 || fileInfo2.Length != fileInfo.Length)
			{
				fileInfo2.Delete();
				fileInfo.CopyTo(text, overwrite: true);
			}
		}
		if (copySubDirs)
		{
			DirectoryInfo[] array = directories;
			foreach (DirectoryInfo directoryInfo2 in array)
			{
				string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
				CopyDirectoryOverwriteIfDifferent(directoryInfo2.FullName, destDirName2, copySubDirs);
			}
		}
	}

	public static string CleanUpXML_CorruptedSlugTrailNames(string string_0)
	{
		if (Regex.Match(string_0, "<(?=\\d)").Success)
		{
			string_0 = Regex.Replace(string_0, "<(?=\\d)", "<TrailedUnitID_");
			string_0 = Regex.Replace(string_0, "<\\/(?=\\d)", "</TrailedUnitID_");
		}
		return string_0;
	}

	public static string CleanUpXML_Headers(string string_0)
	{
		string text = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
		if (string_0.StartsWith(text))
		{
			string_0 = string_0.Remove(0, text.Length);
		}
		if (string_0.StartsWith("<?xml"))
		{
			int num = string_0.IndexOf("?>");
			if (num > -1)
			{
				return string_0.Substring(num + "?>".Length).TrimStart(new char[0]);
			}
		}
		return string_0;
	}

	public static byte[] CleanUpXML_Headers(byte[] byte_0)
	{
		int num = byte_0.Length - 1;
		int num2 = default(int);
		for (int i = 0; i <= num; i++)
		{
			if (Operators.CompareString(Conversions.ToString(Convert.ToChar(byte_0[i])), ">", false) == 0)
			{
				num2 = i;
				break;
			}
		}
		byte[] array = new byte[byte_0.Length - (num2 + 2) + 1];
		byte[] result;
		try
		{
			Array.Copy(byte_0, num2 + 1, array, 0, array.Length);
			byte_0 = array;
			result = byte_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101335", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string CleanUpXML_IllegalCharacters(char[] char_0)
	{
		int toExclusive = char_0.Length;
		char int_;
		Parallel.For(0, toExclusive, [SpecialName] (int i) =>
		{
			int_ = char_0[i];
			if (!smethod_3(int_))
			{
				char_0[i] = '\0';
			}
		});
		return char_0.ToString();
	}

	internal static byte[] CleanUpXML_IllegalCharacters(byte[] byte_0)
	{
		int num = byte_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			if (!bool_0[byte_0[i]])
			{
				byte_0[i] = 0;
			}
		}
		return byte_0;
	}

	private static bool[] smethod_2()
	{
		bool[] array = new bool[256];
		int num = 0;
		do
		{
			array[num] = num == 9 || num == 10 || num == 13 || num >= 32;
			num++;
		}
		while (num <= 255);
		return array;
	}

	private static bool smethod_3(int int_0)
	{
		int result;
		if (int_0 != 9 && int_0 != 10 && int_0 != 13)
		{
			if (int_0 >= 32 && int_0 <= 55295)
			{
				result = 1;
				goto IL_0046;
			}
			if (int_0 < 57344 || int_0 > 65533)
			{
				if (int_0 >= 65536)
				{
					return int_0 <= 1114111;
				}
				return false;
			}
		}
		result = 1;
		goto IL_0046;
		IL_0046:
		return (byte)result != 0;
	}

	public static string CoordinateToString(double Lat, double Lon, Parse_Format_Type CoordinateType)
	{
		if (CoordinateType == Parse_Format_Type.Degree_Minute_Second)
		{
			return CoordsToEnglish(Lat, Lon);
		}
		Coordinate coordinate = new Coordinate(Lat, Lon);
		string text = default(string);
		return CoordinateType switch
		{
			Parse_Format_Type.UTM => coordinate.UTM.ToString(), 
			Parse_Format_Type.MGRS => coordinate.MGRS.ToString(), 
			Parse_Format_Type.Cartesian_ECEF => coordinate.ECEF.ToString(), 
			Parse_Format_Type.Signed_Degree => Conversions.ToString(Math.Round(Lat, 3)) + ", " + Conversions.ToString(Math.Round(Lon, 3)), 
			_ => text, 
		};
	}

	public static string CoordsToEnglish(double Lat, double Lon)
	{
		string text;
		if (Lat > 0.0)
		{
			text = "N";
		}
		else
		{
			text = "S";
			Lat = 0.0 - Lat;
		}
		string text2;
		int num;
		if (Lon > 0.0)
		{
			text2 = "E";
			num = 5;
		}
		else
		{
			text2 = "W";
			Lon = 0.0 - Lon;
			num = 5;
		}
		string[] array = new string[num];
		array[0] = text;
		array[1] = MathFunctions.MinSecToString(MathFunctions.DegToMinSec(Math.Round(Lat, 4)));
		array[2] = ", ";
		array[3] = text2;
		array[4] = MathFunctions.MinSecToString(MathFunctions.DegToMinSec(Math.Round(Lon, 4)));
		return string.Concat(array);
	}

	public static void FixMissingElements(Scenario theScen)
	{
		try
		{
			theScen.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (Information.IsNothing((object)side.MapCenter))
				{
					side.MapCenter = new GeoPoint(0.0, 0.0);
				}
				if (!Information.IsNothing((object)side.CameraAlt))
				{
					if (side.CameraAlt == 0.0)
					{
						side.CameraAlt = 4000000.0;
					}
				}
				else
				{
					side.CameraAlt = 6000000.0;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal static bool ContainsChar(this string theString, char theChar)
	{
		return theString.IndexOf(theChar) != -1;
	}

	internal static bool Contains_IgnoreCase(this string theString, string theKey)
	{
		return theString.IndexOf(theKey, StringComparison.OrdinalIgnoreCase) != -1;
	}

	internal static string RemoveHiddenString(string theString)
	{
		if (!string.IsNullOrEmpty(theString))
		{
			int num = theString.IndexOf('|');
			if (num == -1)
			{
				return theString;
			}
			return Strings.Left(theString, num);
		}
		return string.Empty;
	}

	internal static DateTime LocalTime(DateTime ZuluTime, double theLon, bool DaylightSavingTime, string DaylightSavingTime_Start, string DaylightSavingTime_End)
	{
		DateTime result2;
		try
		{
			DateTime result = ZuluTime.AddHours(Math.Floor((theLon + 7.5) / 15.0));
			if (DaylightSavingTime)
			{
				List<string> list = DaylightSavingTime_Start.Split(new char[1] { '.' }).ToList();
				List<string> list2 = DaylightSavingTime_End.Split(new char[1] { '.' }).ToList();
				if ((Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list2[0]) & Versioned.IsNumeric((object)list2[1])) && (((double)ZuluTime.Day >= Conversions.ToDouble(list[0])) & ((double)ZuluTime.Month >= Conversions.ToDouble(list[1]))) && (((double)ZuluTime.Day <= Conversions.ToDouble(list2[0])) & ((double)ZuluTime.Month <= Conversions.ToDouble(list2[1]))))
				{
					result = result.AddHours(1.0);
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101099", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result2 = default(DateTime);
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	internal static string TimeString(long seconds, int Maintenance = 0, bool ReturnNo = false, bool ReturnZero = false)
	{
		string result;
		if (seconds > 2147483647L)
		{
			result = "Very long";
		}
		else
		{
			TimeSpan timeSpan;
			try
			{
				timeSpan = TimeSpan.FromSeconds((double)seconds);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200091", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = "N/A";
				ProjectData.ClearProjectError();
				goto IL_02fb;
			}
			int num = (int)Math.Floor((double)timeSpan.Days / 7.0);
			int num2 = (int)Math.Floor((double)timeSpan.Days / 30.0);
			int num3 = (int)Math.Floor((double)timeSpan.Days / 365.0);
			result = ((Maintenance == 2) ? "Unavailable" : ((num3 > 0) ? (Conversions.ToString(num3) + " y" + ((num2 - num3 * 12 == 0) ? "" : (" " + Conversions.ToString(num2 - num3 * 12) + " mon")).ToString()) : ((num2 > 0) ? (Conversions.ToString(num2) + " mon" + ((num - num2 * 4 == 0) ? "" : (" " + Conversions.ToString(num - num2 * 4) + " w")).ToString()) : ((num > 0) ? (Conversions.ToString(num) + " w" + ((timeSpan.Days - num * 7 != 0) ? (" " + Conversions.ToString(timeSpan.Days - num * 7) + " d") : "").ToString()) : ((timeSpan.Days > 0) ? (Conversions.ToString(timeSpan.Days) + " d" + ((timeSpan.Hours != 0) ? (" " + Conversions.ToString(timeSpan.Hours) + " hr") : "").ToString()) : ((timeSpan.Hours > 0) ? (Conversions.ToString(timeSpan.Hours) + " hr" + ((timeSpan.Minutes == 0) ? "" : (" " + Conversions.ToString(timeSpan.Minutes) + " min")).ToString()) : ((timeSpan.Minutes > 0) ? (Conversions.ToString(timeSpan.Minutes) + " min" + ((timeSpan.Seconds != 0) ? (" " + Conversions.ToString(timeSpan.Seconds) + " sec") : "").ToString()) : ((timeSpan.Seconds > 0) ? (Conversions.ToString(timeSpan.Seconds) + " sec") : ((timeSpan.Seconds != 0) ? "Error!" : (ReturnNo ? "No" : ((!ReturnZero) ? "Ready" : "0")))))))))));
		}
		goto IL_02fb;
		IL_02fb:
		return result;
	}

	internal static string ByteArrayToHexString(byte[] arrInput)
	{
		StringBuilder stringBuilder = new StringBuilder(arrInput.Length * 2);
		int num = arrInput.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			stringBuilder.Append(arrInput[i].ToString("X2"));
		}
		return stringBuilder.ToString().ToLower();
	}

	public static string ToString(EventTrigger_RegularTime.RegularTimeInterval theInterval)
	{
		return theInterval switch
		{
			EventTrigger_RegularTime.RegularTimeInterval.OneSecond => "One Second", 
			EventTrigger_RegularTime.RegularTimeInterval.FiveSeconds => "Five Seconds", 
			EventTrigger_RegularTime.RegularTimeInterval.FifteenSeconds => "Fifteen Seconds", 
			EventTrigger_RegularTime.RegularTimeInterval.ThirtySeconds => "Thirty Seconds", 
			EventTrigger_RegularTime.RegularTimeInterval.OneMinute => "One Minute", 
			EventTrigger_RegularTime.RegularTimeInterval.FiveMinutes => "Five Minutes", 
			EventTrigger_RegularTime.RegularTimeInterval.FifteenMinutes => "Fifteen Minutes", 
			EventTrigger_RegularTime.RegularTimeInterval.ThirtyMinutes => "Thirty Minutes", 
			EventTrigger_RegularTime.RegularTimeInterval.OneHour => "One Hour", 
			EventTrigger_RegularTime.RegularTimeInterval.SixHours => "Six Hours", 
			EventTrigger_RegularTime.RegularTimeInterval.TwelveHours => "Twelve Hours", 
			EventTrigger_RegularTime.RegularTimeInterval.TwentyFourHours => "Twenty Four Hours", 
			EventTrigger_RegularTime.RegularTimeInterval.EveryPulse => "Every sim pulse", 
			_ => "Error!", 
		};
	}

	public static bool IsEmpty_LockFreeCheck(this ConcurrentDictionary<int, bool> theDic)
	{
		if (!theDic.GetEnumerator().MoveNext())
		{
			return true;
		}
		return false;
	}

	public static bool IsEmpty_LockFreeCheck(this ConcurrentDictionary<(int, string), (ActiveUnit_Weaponry.DLZResultEnum, float)> theDic)
	{
		if (!theDic.GetEnumerator().MoveNext())
		{
			return true;
		}
		return false;
	}

	public static bool IsEmpty_LockFreeCheck(this ConcurrentDictionary<string, Contact> theDic)
	{
		if (theDic.GetEnumerator().MoveNext())
		{
			return false;
		}
		return true;
	}

	public static bool IsEmpty_LockFreeCheck<T, Y>(this ConcurrentDictionary<T, Y> theDic)
	{
		if (theDic.GetEnumerator().MoveNext())
		{
			return false;
		}
		return true;
	}

	public static bool IsEmpty_LockFreeCheck<T, Y>(this ConcurrentObservableDictionary<T, Y> theDic)
	{
		if (theDic.GetEnumerator().MoveNext())
		{
			return false;
		}
		return true;
	}

	public static List<T> Values_ToList<T>(this ConcurrentDictionary<T, T> theDic)
	{
		IEnumerator<KeyValuePair<T, T>> enumerator = theDic.GetEnumerator();
		List<T> list = new List<T>();
		while (enumerator.MoveNext())
		{
			list.Add(enumerator.Current.Value);
		}
		return list;
	}

	public static List<T> Keys_ToList<T>(this ConcurrentDictionary<T, T> theDic)
	{
		IEnumerator<KeyValuePair<T, T>> enumerator = theDic.GetEnumerator();
		List<T> list = new List<T>();
		while (enumerator.MoveNext())
		{
			list.Add(enumerator.Current.Key);
		}
		return list;
	}

	public static bool HasActiveMode(this Sensor.Sensor_Type theType)
	{
		Sensor.Sensor_Type sensor_Type = theType;
		int result;
		int result2;
		if (sensor_Type > Sensor.Sensor_Type.LaserRangefinder)
		{
			if (sensor_Type > Sensor.Sensor_Type.TowedArray_ActiveOnly)
			{
				if ((uint)(sensor_Type - 5022) <= 1u || (uint)(sensor_Type - 5032) <= 1u)
				{
					goto IL_007d;
				}
				if (sensor_Type != Sensor.Sensor_Type.NonDetectingEmitter)
				{
					result = 0;
					goto IL_007a;
				}
				result2 = 1;
			}
			else
			{
				if ((uint)(sensor_Type - 5002) > 1u)
				{
					if ((uint)(sensor_Type - 5012) > 1u)
					{
						result = 0;
						goto IL_007a;
					}
					goto IL_007d;
				}
				result2 = 1;
			}
			goto IL_007e;
		}
		if (sensor_Type <= Sensor.Sensor_Type.ECM)
		{
			if (sensor_Type != Sensor.Sensor_Type.Radar && sensor_Type != Sensor.Sensor_Type.ECM)
			{
				result = 0;
				goto IL_007a;
			}
		}
		else if (sensor_Type != Sensor.Sensor_Type.LaserDesignator && sensor_Type != Sensor.Sensor_Type.LaserRangefinder)
		{
			result = 0;
			goto IL_007a;
		}
		goto IL_007d;
		IL_007d:
		result2 = 1;
		goto IL_007e;
		IL_007a:
		return (byte)result != 0;
		IL_007e:
		return (byte)result2 != 0;
	}

	public static void Shuffle<T>(this IList<T> list)
	{
		RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
		int num = list.Count;
		while (num > 1)
		{
			byte[] array = new byte[1];
			do
			{
				rNGCryptoServiceProvider.GetBytes(array);
			}
			while (!((double)(int)array[0] < (double)num * (255.0 / (double)num)));
			int index = array[0] % num;
			num--;
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public static void ShuffleArray<T>(ref T[] array)
	{
		Random random = new Random();
		for (int i = array.Length - 1; i >= 1; i += -1)
		{
			int num = random.Next(i + 1);
			T val = array[i];
			array[i] = array[num];
			array[num] = val;
		}
	}

	public static void Clear<T>(this ConcurrentQueue<T> theQueue)
	{
		T result;
		while (theQueue.TryDequeue(out result))
		{
		}
	}

	internal static int CommonMaximumSpeed(this IEnumerable<ActiveUnit> theUnits)
	{
		int result;
		try
		{
			int num = 999999999;
			foreach (ActiveUnit theUnit in theUnits)
			{
				int maximumSpeed = theUnit.Kinematics.GetMaximumSpeed(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false);
				if (maximumSpeed < num)
				{
					num = maximumSpeed;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101098", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static int CountOccurrences(this string SourceString, string DesiredString)
	{
		int result;
		if (DesiredString != null)
		{
			if (DesiredString.Length != 0)
			{
				return (int)Math.Round((double)(SourceString.Length - SourceString.Replace(DesiredString, string.Empty).Length) / (double)DesiredString.Length);
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	internal static bool Contains_CommonCount(this string SourceString, string DesiredString)
	{
		return (double)(SourceString.Length - SourceString.Replace(DesiredString, string.Empty).Length) / (double)DesiredString.Length == 1.0;
	}

	internal static string ToEnglishString(this Aircraft.CockpitVisibility theVisibility)
	{
		return theVisibility switch
		{
			Aircraft.CockpitVisibility.Excellent => "Excellent", 
			Aircraft.CockpitVisibility.Average => "Average", 
			Aircraft.CockpitVisibility.Poor => "Poor", 
			_ => "Error!", 
		};
	}

	internal static string ToEnglishString(this Warhead.WarheadCaliber theCaliber)
	{
		switch (theCaliber)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return "ERROR";
		case Warhead.WarheadCaliber.Rocket_6_15mm:
			return "Rocket (6-15mm)";
		case Warhead.WarheadCaliber.Rocket_16_24mm:
			return "Rocket (16-24mm)";
		case Warhead.WarheadCaliber.Rocket_25_60mm:
			return "Rocket (25-60mm)";
		case Warhead.WarheadCaliber.Rocket_61_80mm:
			return "Rocket (61-80mm)";
		case Warhead.WarheadCaliber.Rocket_81_150mm:
			return "Rocket (81-150mm)";
		case Warhead.WarheadCaliber.Rocket_151_200mm:
			return "Rocket (151-200mm)";
		case Warhead.WarheadCaliber.Rocket_201_350mm:
			return "Rocket (201-350mm)";
		case Warhead.WarheadCaliber.Rocket_351_450mm:
			return "Rocket (351-450mm)";
		case Warhead.WarheadCaliber.Gun_6_15mm:
			return "Gun (6-15mm)";
		case Warhead.WarheadCaliber.Gun_16_24mm:
			return "Gun (16-24mm)";
		case Warhead.WarheadCaliber.Gun_25_60mm:
			return "Gun (25-60mm)";
		case Warhead.WarheadCaliber.Gun_61_80mm:
			return "Gun (61-80mm)";
		case Warhead.WarheadCaliber.Gun_81_150mm:
			return "Gun (81-150mm)";
		case Warhead.WarheadCaliber.Gun_151_200mm:
			return "Gun (151-200mm)";
		case Warhead.WarheadCaliber.Gun_201_350mm:
			return "Gun (201-350mm)";
		case Warhead.WarheadCaliber.Gun_351_450mm:
			return "Gun (351-450mm)";
		case Warhead.WarheadCaliber.None:
			return "None";
		}
	}

	internal static string ToEnglishString(this GlobalVariables.ProficiencyLevel theProfLevel)
	{
		return theProfLevel switch
		{
			GlobalVariables.ProficiencyLevel.Novice => "Novice", 
			GlobalVariables.ProficiencyLevel.Cadet => "Cadet", 
			GlobalVariables.ProficiencyLevel.Regular => "Regular", 
			GlobalVariables.ProficiencyLevel.Veteran => "Veteran", 
			GlobalVariables.ProficiencyLevel.Ace => "Ace", 
			_ => "Error!", 
		};
	}

	internal static bool HasNukes(this IEnumerable<Weapon> theList)
	{
		bool result;
		try
		{
			foreach (Weapon the in theList)
			{
				if (!the.IsNuke.Value)
				{
					continue;
				}
				result = true;
				goto end_IL_0001;
			}
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101097", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ShuffleList<T>(IList<T> list)
	{
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = GameGeneral.GlobalRNG.Next(num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public static string ToEnglishString(this Sensor.DetectionAttemptType theAttemptType)
	{
		return theAttemptType switch
		{
			Sensor.DetectionAttemptType.VolumeSearch => "Search", 
			Sensor.DetectionAttemptType.SpecificTargetTracking => "SpecificTargetTrack", 
			Sensor.DetectionAttemptType.WeaponGuidance => "WeaponGuidance", 
			Sensor.DetectionAttemptType.Recon => "Recon", 
			_ => theAttemptType.ToString(), 
		};
	}

	public static string ToEnglishString(this LoggedMessage.MessageType theType)
	{
		return theType switch
		{
			LoggedMessage.MessageType.NewContact => "New Contact", 
			LoggedMessage.MessageType.ContactChange => "Contact change", 
			LoggedMessage.MessageType.WeaponEndgame => "Weapon Endgame Calculations", 
			LoggedMessage.MessageType.WeaponDamage => "Weapon Damage", 
			LoggedMessage.MessageType.AirOps => "Air Operations", 
			LoggedMessage.MessageType.UnitLost => "Unit Lost", 
			LoggedMessage.MessageType.UnitDamage => "Unit Damage", 
			LoggedMessage.MessageType.PointDefence => "Point Defence", 
			LoggedMessage.MessageType.UI => "User Interface", 
			LoggedMessage.MessageType.WeaponLogic => "Weapon Logic", 
			LoggedMessage.MessageType.UnitAI => "Unit AI", 
			LoggedMessage.MessageType.EventEngine => "Scenario Events", 
			LoggedMessage.MessageType.NewWeaponContact => "New Weapon Contact", 
			LoggedMessage.MessageType.DockingOps => "Docking Operations", 
			LoggedMessage.MessageType.SpecialMessage => "Special Messages", 
			LoggedMessage.MessageType.NewMineContact => "New Mine Contact", 
			LoggedMessage.MessageType.CommsIsolatedMessage => "Comms-isolated Message", 
			LoggedMessage.MessageType.NewAirContact => "New Air Contact", 
			LoggedMessage.MessageType.NewSurfaceContact => "New Surface Contact", 
			LoggedMessage.MessageType.NewUnderwaterContact => "New Underwater Contact", 
			LoggedMessage.MessageType.NewGroundContact => "New Ground Contact", 
			LoggedMessage.MessageType.UnguidedWeaponModifiers => "Unguided Weapon Accuracy Modifiers", 
			LoggedMessage.MessageType.const_23 => "Doctrine & ROE", 
			LoggedMessage.MessageType.Debug => "Debug", 
			LoggedMessage.MessageType.UnitAIEmergency => "Unit AI Emergency", 
			LoggedMessage.MessageType.CommsRelatedMessage => "Comms-related Message", 
			_ => theType.ToString(), 
		};
	}

	public static string ToEnglishString(this IMobileGroundUnit._MobileUnitCategory theCategory)
	{
		switch (theCategory)
		{
		case IMobileGroundUnit._MobileUnitCategory.Anti_Tank:
			return "Anti-tank";
		case IMobileGroundUnit._MobileUnitCategory.Motorized_Infantry:
			return "Motorised Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Headquarters:
			return "HQ";
		case IMobileGroundUnit._MobileUnitCategory.Radar:
			return "Radar";
		case IMobileGroundUnit._MobileUnitCategory.MechWheeled:
			return "Wheeled Infantry";
		case IMobileGroundUnit._MobileUnitCategory.MechAirborne:
			return "Airborne Mech Infantry";
		case IMobileGroundUnit._MobileUnitCategory.MechMarines:
			return "Naval Mech Infantry";
		case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
			return "Mechanized Infantry";
		case IMobileGroundUnit._MobileUnitCategory.AAA:
			return "AAA";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
			return "Missile Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Engineer:
			return "Engineer";
		case IMobileGroundUnit._MobileUnitCategory.SAM:
			return "SAM";
		case IMobileGroundUnit._MobileUnitCategory.Surveillance:
			return "Surveillance";
		case IMobileGroundUnit._MobileUnitCategory.Supply:
			return "Supply";
		case IMobileGroundUnit._MobileUnitCategory.Amphibious_Recon:
			return "Amphib Recon";
		case IMobileGroundUnit._MobileUnitCategory.Recon:
			return "Reconnaisance";
		case IMobileGroundUnit._MobileUnitCategory.Combined_Arms:
			return "Combined Arms";
		case IMobileGroundUnit._MobileUnitCategory.Special_Forces:
			return "Special Forces";
		case IMobileGroundUnit._MobileUnitCategory.Airborne:
			return "Airborne Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Mountain:
			return "Mountain Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Air_Assault:
			return "Air Assault";
		case IMobileGroundUnit._MobileUnitCategory.Marines:
			return "Naval Infantry";
		case IMobileGroundUnit._MobileUnitCategory.None:
			return "None";
		case IMobileGroundUnit._MobileUnitCategory.Infantry:
			return "Infantry";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Mortar:
			return "Mortar Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Tracked:
			return "Rocket Tracked Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Rocket_Wheeled:
			return "Rocket Wheeled Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_SP:
			return "SP Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
			return "Towed Artillery";
		case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
			return "Artillery";
		default:
			_ = Debugger.IsAttached;
			return theCategory.ToString();
		case IMobileGroundUnit._MobileUnitCategory.Armor_Recon:
			return "Armor Recon";
		case IMobileGroundUnit._MobileUnitCategory.Armor:
			return "Armor";
		}
	}

	public static string ToEnglishString(this Scenario.ScenarioFeatureOption theFeature)
	{
		switch (theFeature)
		{
		case Scenario.ScenarioFeatureOption.None:
			return "None";
		case Scenario.ScenarioFeatureOption.DetailedGunFireControl:
			return "Unguided weapons accuracy suffers from various factors.";
		case Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines:
			return "Infinite munitions for units available at air and naval bases.";
		case Scenario.ScenarioFeatureOption.AircraftDamage:
			return "More realistic & detailed modelling of aircraft battle damage";
		case Scenario.ScenarioFeatureOption.CommsJamming:
			return "Unit communications can be disrupted by electronic jamming";
		case Scenario.ScenarioFeatureOption.CommsDisruption:
			return "Unit communications can be disrupted by non-electronic means";
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return theFeature.ToString();
		case Scenario.ScenarioFeatureOption.RealisticSubComms:
			return "Realistic Submarine Communications";
		case Scenario.ScenarioFeatureOption.LandTypeEffects:
			return "Terrain type affects mobility, sensor spotting and weapon effects";
		case Scenario.ScenarioFeatureOption.FixedSideColors:
			return "Sides have fixed colors for own and adversary units, so posture-dictated colors do not apply";
		case Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed:
			return "Weather (esp. wind & sea state) restricts the maximum speed of surface ships";
		case Scenario.ScenarioFeatureOption.AllowLandingPlannerInstantLoading:
			return "Allow instant loading of units on Landing Planner";
		case Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced:
			return "Sensors are blocked by local 'culture height' (e.g. trees in a forest) unless they clear the skyline (e.g. with a mast). DO NOT USE unless you really understand the effects";
		case Scenario.ScenarioFeatureOption.ACS_NAW_Limitations:
			return "Weather condition and time of the day will prevent aircrafts from take off and may damage or destroy them during landing";
		case Scenario.ScenarioFeatureOption.DroneAutonomyLevels:
			return "Unmanned platforms have various levels of autonomous capability when out of comms; everything from 'go blind and do nothing' all the way to 'continue with almost-human autonomy'";
		case Scenario.ScenarioFeatureOption.ASCMTerrainFollowingRestriction:
			return "Low-flying anti-ship cruise missiles who do not have a terrain-following capability cannot fly overland";
		case Scenario.ScenarioFeatureOption.PointToPointComm:
			return "Contacts will not be immediatly shared with all the units at side level but every platform will need to transmit to other units what they have detected via a valid comm device";
		case Scenario.ScenarioFeatureOption.RealisticOrderChain:
			return "Order to units will be propagated from the HQ using realistic transmission time, this requires Point to Point comm to be enabled";
		case Scenario.ScenarioFeatureOption.VariableBurnoutSpeed:
			return "The burnout speed on boost-coast weapons varies with launch speed";
		case Scenario.ScenarioFeatureOption.LimitedSonobuoysInMagazines:
			return "Sonobuoy reloads are limited by munitions available in base magazines";
		}
	}

	internal static string Description(this Satellite._SatelliteType theType, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select ST.Description from EnumSatelliteType As ST where ST.ID = " + Conversions.ToString((int)theType));
	}

	internal static string Description(this Satellite._SatelliteCategory theCategory, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select SC.Description from EnumSatelliteCategory As SC where SC.ID = " + Conversions.ToString((int)theCategory));
	}

	internal static float CommonMaximumAltitude(this IEnumerable<ActiveUnit> theUnits)
	{
		float result;
		try
		{
			float num = 1E+09f;
			foreach (ActiveUnit theUnit in theUnits)
			{
				float maximumAltitude = theUnit.Kinematics.GetMaximumAltitude();
				if (maximumAltitude < num)
				{
					num = maximumAltitude;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101096", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static int CommonMinimumSpeed(this IEnumerable<ActiveUnit> theUnits)
	{
		int result;
		try
		{
			int num = 0;
			foreach (ActiveUnit theUnit in theUnits)
			{
				int num2 = (int)Math.Round(theUnit.Kinematics.GetMinimumSpeed_Total(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false));
				if (num2 > num)
				{
					num = num2;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101095", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static string Description(this Engine.EngineType thePropulsionType, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select PT.Description from EnumPropulsionType As PT where PT.ID = " + Conversions.ToString((int)thePropulsionType));
	}

	internal static string Description(this FuelRec._FuelType theFuelType, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select FT.Description from EnumFuelType As FT where FT.ID = " + Conversions.ToString((int)theFuelType));
	}

	internal static string Description(this Facility._FacilityCategory theCategory, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select FC.Description from EnumFacilityCategory As FC where FC.ID = " + Conversions.ToString((int)theCategory));
	}

	internal static string Description(this Loadout._LoadoutDayNight theTOD)
	{
		return theTOD switch
		{
			Loadout._LoadoutDayNight.DayNight => "Day/Night", 
			Loadout._LoadoutDayNight.NightOnly => "Night only", 
			Loadout._LoadoutDayNight.DayOnly => "Day only", 
			Loadout._LoadoutDayNight.None => "", 
			_ => "Error!", 
		};
	}

	internal static string Description(this Loadout._LoadoutWeather theW)
	{
		return theW switch
		{
			Loadout._LoadoutWeather.AllWeather => "All-Weather", 
			Loadout._LoadoutWeather.LimitedAllWeather => "Limited All-Weather", 
			Loadout._LoadoutWeather.ClearWeather => "Clear-Weather", 
			Loadout._LoadoutWeather.None => "", 
			_ => "Error!", 
		};
	}

	internal static string Description(this Loadout.LoadoutRole theRole, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select LR.Description from EnumLoadoutRole As LR where LR.ID = " + Conversions.ToString((int)theRole));
	}

	internal static string Description(this Aircraft._AircraftType theType, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select AT.Description from EnumAircraftType As AT where AT.ID = " + Conversions.ToString((int)theType));
	}

	internal static string Description(this Aircraft._AircraftCategory theCategory, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select AC.Description from EnumAircraftCategory As AC where AC.ID = " + Conversions.ToString((int)theCategory));
	}

	internal static string Description(this GlobalVariables.AircraftSizeClass theSizeClass, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		int dBAircraftPhysicalSize = DBFunctions.GetDBAircraftPhysicalSize(theSizeClass);
		return DBCache.GetScalar(theHelper, "Select APS.Description from EnumAircraftPhysicalSize As APS where APS.ID = " + Conversions.ToString(dBAircraftPhysicalSize));
	}

	internal static string Description(this Ship._ShipType theType, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select ST.Description from EnumShipType As ST where ST.ID = " + Conversions.ToString((int)theType));
	}

	internal static string Description(this Ship._ShipCategory theCategory, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select ST.Description from EnumShipCategory As ST where ST.ID = " + Conversions.ToString((int)theCategory));
	}

	internal static string Description(this Submarine._SubmarineType theType, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select ST.Description from EnumSubmarineType As ST where ST.ID = " + Conversions.ToString((int)theType));
	}

	internal static string Description(this Submarine._SubmarineCategory theCategory, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select ST.Description from EnumSubmarineCategory As ST where ST.ID = " + Conversions.ToString((int)theCategory));
	}

	internal static string Description(this GlobalVariables.ArmorRating theArmor, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		if (theArmor == GlobalVariables.ArmorRating.None)
		{
			return "None";
		}
		return DBCache.GetScalar(theHelper, "Select AT.Description from EnumArmorType As AT where AT.ID = " + Conversions.ToString((int)theArmor));
	}

	internal static string Description(this DockFacility.DockingPhysicalSize theDockSize, SQLiteConnection sqliteConnection_0)
	{
		return DBCache.GetScalar(new SQLiteHelper(sqliteConnection_0), "Select Description from EnumDockingFacilityPhysicalSize where ID = " + Conversions.ToString((int)theDockSize));
	}

	internal static string Description(this GlobalVariables.RunwayLengthClass theRunwayLengthClass, SQLiteConnection sqliteConnection_0)
	{
		SQLiteHelper theHelper = new SQLiteHelper(sqliteConnection_0);
		string text = "EnumRunwayLength";
		if (DBOps.DBHasLegacyRunwayLengthEnum)
		{
			text = "EnumAircraftRunwayLength";
		}
		int dBRunwayLength = DBFunctions.GetDBRunwayLength(theRunwayLengthClass);
		return DBCache.GetScalar(theHelper, "Select ARL.Description from " + text + " As ARL where ARL.ID = " + Conversions.ToString(dBRunwayLength));
	}

	internal static float CommonMinimumAltitude(this IEnumerable<ActiveUnit> theUnits)
	{
		float result;
		try
		{
			float num = 0f;
			foreach (ActiveUnit theUnit in theUnits)
			{
				float minimumAltitude = theUnit.Kinematics.GetMinimumAltitude();
				if (minimumAltitude > num)
				{
					num = minimumAltitude;
				}
			}
			result = num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101094", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void AddOrUpdate(this Dictionary<string, bool> dic, string key, bool newValue)
	{
		if (!dic.TryGetValue(key, out var _))
		{
			dic.Add(key, newValue);
		}
		else
		{
			dic[key] = newValue;
		}
	}

	internal static string FirstWord(this string aString)
	{
		string result;
		try
		{
			int num = aString.IndexOf(' ');
			result = ((num != -1) ? aString.Substring(0, num) : aString);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101088", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "Error!";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static string AsString(this ActiveUnit.Throttle theT, ActiveUnit theUnit)
	{
		switch (theT)
		{
		default:
			return "UNDEFINED!";
		case ActiveUnit.Throttle.FullStop:
			if (theUnit.IsAircraft && ((Aircraft)theUnit).get_CanHover(bool_7: false))
			{
				return "Hover";
			}
			if (!theUnit.AI.HoldPosition)
			{
				return "Full Stop";
			}
			return "HOLD";
		case ActiveUnit.Throttle.Loiter:
			if (!theUnit.IsAircraft && !theUnit.IsMissile)
			{
				string text = "Creep";
				if (theUnit.Kinematics.HasAdjustedSpeedForCavitation)
				{
					text += " - No-Cav";
				}
				return text;
			}
			return "Loiter";
		case ActiveUnit.Throttle.Cruise:
		{
			string text = "Cruise";
			if (theUnit.Kinematics.HasAdjustedSpeedForCavitation)
			{
				text += " - No-Cav";
			}
			return text;
		}
		case ActiveUnit.Throttle.Full:
		{
			string text = "Full";
			if (theUnit.Kinematics.HasAdjustedSpeedForCavitation)
			{
				text += " - No-Cav";
			}
			return text;
		}
		case ActiveUnit.Throttle.Flank:
			if (!theUnit.IsAircraft && !theUnit.IsMissile)
			{
				string text = "Flank";
				if (theUnit.Kinematics.HasAdjustedSpeedForCavitation)
				{
					text += " - No-Cav";
				}
				return text;
			}
			return "Afterburner";
		}
	}

	internal static string ActiveUnitType_Description(this GlobalVariables.ActiveUnitType theType)
	{
		return theType switch
		{
			GlobalVariables.ActiveUnitType.None => "None", 
			GlobalVariables.ActiveUnitType.Aircraft => "Aircraft", 
			GlobalVariables.ActiveUnitType.Ship => "Ship", 
			GlobalVariables.ActiveUnitType.Submarine => "Submarine", 
			GlobalVariables.ActiveUnitType.Facility => "Facility", 
			GlobalVariables.ActiveUnitType.Aimpoint => "Aimpoint", 
			GlobalVariables.ActiveUnitType.Weapon => "Weapon", 
			GlobalVariables.ActiveUnitType.Satellite => "Satellite", 
			GlobalVariables.ActiveUnitType.Vehicle => "Ground Unit", 
			_ => throw new NotImplementedException(), 
		};
	}

	internal static XmlNode GetNodeByName(this XmlNodeList theList, string theName)
	{
		XmlNode result;
		try
		{
			int num = theList.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					XmlNode val = theList[num2];
					if (string.CompareOrdinal(val.Name, theName) != 0)
					{
						num2++;
						continue;
					}
					result = val;
					break;
				}
				result = null;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101093", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static string ConvertToString(this Stream theStream)
	{
		long position = theStream.Position;
		theStream.Position = 0L;
		string result = new StreamReader(theStream).ReadToEnd();
		theStream.Position = position;
		return result;
	}

	internal static Geopoint_Struct Center(this List<GeoPoint> theArea)
	{
		Geopoint_Struct result;
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			_ = theArea.Count;
			int num4 = theArea.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				GeoPoint geoPoint = theArea[i];
				double num5 = 0.0174532925199433 * geoPoint.Latitude;
				double num6 = 0.0174532925199433 * geoPoint.Longitude;
				double num7 = Math.Cos(num5);
				double num8 = num7 * Math.Cos(num6);
				double num9 = num7 * Math.Sin(num6);
				double num10 = Math.Sin(num5);
				num += num8;
				num2 += num9;
				num3 += num10;
			}
			double num11 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) + Math.Pow(num3, 2.0));
			num /= num11;
			num2 /= num11;
			num3 /= num11;
			double num12 = Math.Atan2(num2, num);
			double x = Math.Sqrt(num * num + num2 * num2);
			double num13 = Math.Atan2(num3, x);
			return new Geopoint_Struct(57.2957795130823 * num12, 57.2957795130823 * num13);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101332", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static Geopoint_Struct Center(this Geopoint_Struct[] theArea)
	{
		Geopoint_Struct result;
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = theArea.Length - 1;
			for (int i = 0; i <= num4; i++)
			{
				Geopoint_Struct geopoint_Struct = theArea[i];
				double num5 = 0.0174532925199433 * geopoint_Struct.Latitude;
				double num6 = 0.0174532925199433 * geopoint_Struct.Longitude;
				double num7 = Math.Cos(num5);
				double num8 = num7 * Math.Cos(num6);
				double num9 = num7 * Math.Sin(num6);
				double num10 = Math.Sin(num5);
				num += num8;
				num2 += num9;
				num3 += num10;
			}
			double num11 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) + Math.Pow(num3, 2.0));
			num /= num11;
			num2 /= num11;
			num3 /= num11;
			double num12 = Math.Atan2(num2, num);
			double x = Math.Sqrt(num * num + num2 * num2);
			double num13 = Math.Atan2(num3, x);
			return new Geopoint_Struct(57.2957795130823 * num12, 57.2957795130823 * num13);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101332", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static Geopoint_Struct Center(this PooledList<Geopoint_Struct> theArea)
	{
		Geopoint_Struct result;
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = theArea.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				Geopoint_Struct geopoint_Struct = theArea[i];
				if (!double.IsNaN(geopoint_Struct.Latitude) && !double.IsNaN(geopoint_Struct.Longitude))
				{
					double num5 = 0.0174532925199433 * geopoint_Struct.Latitude;
					double num6 = 0.0174532925199433 * geopoint_Struct.Longitude;
					double num7 = Math.Cos(num5);
					double num8 = num7 * Math.Cos(num6);
					double num9 = num7 * Math.Sin(num6);
					double num10 = Math.Sin(num5);
					num += num8;
					num2 += num9;
					num3 += num10;
				}
			}
			double num11 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) + Math.Pow(num3, 2.0));
			num /= num11;
			num2 /= num11;
			num3 /= num11;
			double num12 = Math.Atan2(num2, num);
			double x = Math.Sqrt(num * num + num2 * num2);
			double num13 = Math.Atan2(num3, x);
			return new Geopoint_Struct(57.2957795130823 * num12, 57.2957795130823 * num13);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 103245324059", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static Geopoint_Struct Center(this List<Geopoint_Struct> theArea)
	{
		Geopoint_Struct result;
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = theArea.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				Geopoint_Struct geopoint_Struct = theArea[i];
				if (!double.IsNaN(geopoint_Struct.Latitude) && !double.IsNaN(geopoint_Struct.Longitude))
				{
					double num5 = 0.0174532925199433 * geopoint_Struct.Latitude;
					double num6 = 0.0174532925199433 * geopoint_Struct.Longitude;
					double num7 = Math.Cos(num5);
					double num8 = num7 * Math.Cos(num6);
					double num9 = num7 * Math.Sin(num6);
					double num10 = Math.Sin(num5);
					num += num8;
					num2 += num9;
					num3 += num10;
				}
			}
			double num11 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) + Math.Pow(num3, 2.0));
			num /= num11;
			num2 /= num11;
			num3 /= num11;
			double num12 = Math.Atan2(num2, num);
			double x = Math.Sqrt(num * num + num2 * num2);
			double num13 = Math.Atan2(num3, x);
			return new Geopoint_Struct(57.2957795130823 * num12, 57.2957795130823 * num13);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 103245324059", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static GeoPoint Center(this GeoPoint[] theArea)
	{
		GeoPoint result;
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = theArea.Length - 1;
			for (int i = 0; i <= num4; i++)
			{
				GeoPoint geoPoint = theArea[i];
				double num5 = 0.0174532925199433 * geoPoint.Latitude;
				double num6 = 0.0174532925199433 * geoPoint.Longitude;
				double num7 = Math.Cos(num5);
				double num8 = num7 * Math.Cos(num6);
				double num9 = num7 * Math.Sin(num6);
				double num10 = Math.Sin(num5);
				num += num8;
				num2 += num9;
				num3 += num10;
			}
			double num11 = Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) + Math.Pow(num3, 2.0));
			num /= num11;
			num2 /= num11;
			num3 /= num11;
			double num12 = Math.Atan2(num2, num);
			double x = Math.Sqrt(num * num + num2 * num2);
			double num13 = Math.Atan2(num3, x);
			result = new GeoPoint(57.2957795130823 * num12, 57.2957795130823 * num13);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101332", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new GeoPoint(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static Geopoint_Struct Center(this List<ReferencePoint> theArea)
	{
		Geopoint_Struct result;
		try
		{
			List<GeoPoint> list = new List<GeoPoint>();
			int num = theArea.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					list.Add(theArea[i]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			return Center(list);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101331", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Geopoint_Struct(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static GeoPoint CenterCartesian(this List<GeoPoint> theArea)
	{
		GeoPoint result;
		try
		{
			if (GeoPoint.PolygonCrossesAntimeridian(theArea))
			{
				List<GeoPoint> list = new List<GeoPoint>();
				foreach (GeoPoint item in theArea)
				{
					list.Add(new GeoPoint(Math2.NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
				}
				if (GeoPoint.PolygonCrossesAntimeridian(list))
				{
					double theLat = list.Select([SpecialName] (GeoPoint theGP) => theGP.Latitude).Average();
					double theLon = list.Select([SpecialName] (GeoPoint theGP) => theGP.Longitude).Average() + 180.0;
					result = new GeoPoint(theLon, theLat);
				}
				else
				{
					Geopoint_Struct geopoint_Struct = Center(list);
					result = new GeoPoint(Math2.NormalizeLongitude(geopoint_Struct.Longitude - 180.0), geopoint_Struct.Latitude);
				}
			}
			else
			{
				int count = theArea.Count;
				double num = theArea.Select([SpecialName] (GeoPoint theRP) => theRP.Latitude).Sum();
				double num2 = theArea.Select([SpecialName] (GeoPoint theRP) => theRP.Longitude).Sum();
				result = new GeoPoint(num2 / (double)count, num / (double)count);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101089", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new GeoPoint(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static GeoPoint CenterCartesian(this List<ReferencePoint> theArea)
	{
		GeoPoint result;
		try
		{
			if (!GeoPoint.PolygonCrossesAntimeridian(theArea))
			{
				int count = theArea.Count;
				double num = theArea.Select([SpecialName] (ReferencePoint theRP) => theRP.Latitude).Sum();
				double num2 = theArea.Select([SpecialName] (ReferencePoint theRP) => theRP.Longitude).Sum();
				result = new GeoPoint(num2 / (double)count, num / (double)count);
			}
			else
			{
				List<GeoPoint> list = new List<GeoPoint>();
				foreach (ReferencePoint item in theArea)
				{
					list.Add(new GeoPoint(Math2.NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
				}
				if (GeoPoint.PolygonCrossesAntimeridian(list))
				{
					double theLat = list.Select([SpecialName] (GeoPoint theGP) => theGP.Latitude).Average();
					double theLon = list.Select([SpecialName] (GeoPoint theGP) => theGP.Longitude).Average() + 180.0;
					result = new GeoPoint(theLon, theLat);
				}
				else
				{
					Geopoint_Struct geopoint_Struct = Center(list);
					result = new GeoPoint(Math2.NormalizeLongitude(geopoint_Struct.Longitude - 180.0), geopoint_Struct.Latitude);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101090", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new GeoPoint(0.0, 0.0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static bool CrossesAPole(this List<ReferencePoint> theArea)
	{
		bool result;
		try
		{
			if (GeoPoint.PolygonCrossesAntimeridian(theArea))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				foreach (ReferencePoint item in theArea)
				{
					list.Add(new Geopoint_Struct(Math2.NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
				}
				result = GeoPoint.PolygonCrossesAntimeridian(list);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101091", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static bool CrossesAPole(this List<GeoPoint> theArea)
	{
		bool result;
		try
		{
			if (GeoPoint.PolygonCrossesAntimeridian(theArea))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(theArea.Count);
				foreach (GeoPoint item in theArea)
				{
					list.Add(new Geopoint_Struct(Math2.NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
				}
				result = GeoPoint.PolygonCrossesAntimeridian(list);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101091", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static bool CrossesAPole(this PooledList<Geopoint_Struct> theArea)
	{
		bool result;
		try
		{
			if (GeoPoint.PolygonCrossesAntimeridian(theArea))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(theArea.Count);
				foreach (Geopoint_Struct item in theArea)
				{
					list.Add(new Geopoint_Struct(Math2.NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
				}
				result = GeoPoint.PolygonCrossesAntimeridian(list);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 121345698989", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 0;
			}
			else
			{
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static bool CrossesAPole(this List<Geopoint_Struct> theArea)
	{
		bool result;
		try
		{
			if (GeoPoint.PolygonCrossesAntimeridian(theArea))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(theArea.Count);
				foreach (Geopoint_Struct item in theArea)
				{
					list.Add(new Geopoint_Struct(Math2.NormalizeLongitude(item.Longitude + 180.0), item.Latitude));
				}
				result = GeoPoint.PolygonCrossesAntimeridian(list);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 121345698989", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static string GetReflectedPropertyValue(this ScenarioObject subject, string field)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(subject.GetType().GetProperty(field).GetValue(subject, null));
		if (objectValue == null)
		{
			return "";
		}
		return objectValue.ToString();
	}

	internal static string ToEnglishString(this GlobalVariables.TechGenerationClass theGen)
	{
		return theGen switch
		{
			GlobalVariables.TechGenerationClass.IR_SingleSpectral => "Single-spectral IR", 
			GlobalVariables.TechGenerationClass.IR_DualSpectral => "Dual-spectral IR", 
			GlobalVariables.TechGenerationClass.IR_Imaging_FPA => "Imaging IR", 
			GlobalVariables.TechGenerationClass.const_2 => "Early 1950S", 
			GlobalVariables.TechGenerationClass.const_3 => "Late 1950S", 
			GlobalVariables.TechGenerationClass.const_4 => "Early 1960S", 
			GlobalVariables.TechGenerationClass.const_5 => "Late 1960S", 
			GlobalVariables.TechGenerationClass.const_6 => "Early 1970S", 
			GlobalVariables.TechGenerationClass.const_7 => "Late 1970S", 
			GlobalVariables.TechGenerationClass.const_8 => "Early 1980S", 
			GlobalVariables.TechGenerationClass.const_9 => "Late 1980S", 
			GlobalVariables.TechGenerationClass.const_10 => "Early 1990S", 
			GlobalVariables.TechGenerationClass.const_11 => "Late 1990S", 
			GlobalVariables.TechGenerationClass.const_12 => "Early 2000S", 
			GlobalVariables.TechGenerationClass.const_13 => "Late 2000S", 
			GlobalVariables.TechGenerationClass.const_14 => "Early 2010S", 
			GlobalVariables.TechGenerationClass.const_15 => "Late 2010S", 
			GlobalVariables.TechGenerationClass.const_17 => "Late 2020S", 
			GlobalVariables.TechGenerationClass.NotApplicable => "N/A", 
			_ => theGen.ToString(), 
		};
	}

	internal static string ToEnglishString(this Mission.MissionAssignmentAttemptResult theResult)
	{
		return theResult switch
		{
			Mission.MissionAssignmentAttemptResult.Success => "Success", 
			Mission.MissionAssignmentAttemptResult.Fail_OutOfComms => "Failure - Unit Is out-Of-comms", 
			Mission.MissionAssignmentAttemptResult.Fail_Other => "Failure - undefined reason", 
			_ => theResult.ToString(), 
		};
	}

	internal static string ToEnglishString(this ActiveUnit_Damage.FireIntensityLevel? theFireIntensity)
	{
		ActiveUnit_Damage.FireIntensityLevel? fireIntensityLevel = theFireIntensity;
		byte? b = (byte?)fireIntensityLevel;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
		{
			return "No Fire";
		}
		b = (byte?)fireIntensityLevel;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
		{
			return "Minor Fire";
		}
		b = (byte?)fireIntensityLevel;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
		{
			return "Major Fire";
		}
		b = (byte?)fireIntensityLevel;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
		{
			b = (byte?)fireIntensityLevel;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
			{
				return "Conflagration";
			}
			return theFireIntensity.ToString();
		}
		return "Severe Fire";
	}

	internal static string ToEnglishString(this ActiveUnit_Damage.FloodingIntensityLevel? theFloodIntensity)
	{
		ActiveUnit_Damage.FloodingIntensityLevel? floodingIntensityLevel = theFloodIntensity;
		byte? b = (byte?)floodingIntensityLevel;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
		{
			b = (byte?)floodingIntensityLevel;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
			{
				b = (byte?)floodingIntensityLevel;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
				{
					return "Major Flooding";
				}
				b = (byte?)floodingIntensityLevel;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
				{
					b = (byte?)floodingIntensityLevel;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
					{
						return "Capsizing imminent";
					}
					return theFloodIntensity.ToString();
				}
				return "Severe Flooding";
			}
			return "Minor Flooding";
		}
		return "No Flooding";
	}

	internal static string ToEnglishString(this Contact.BDA_StructuralIntegrityLevel? theStructuralIntegrity)
	{
		Contact.BDA_StructuralIntegrityLevel? bDA_StructuralIntegrityLevel = theStructuralIntegrity;
		byte? b = (byte?)bDA_StructuralIntegrityLevel;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
		{
			return "No damage";
		}
		b = (byte?)bDA_StructuralIntegrityLevel;
		if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
		{
			b = (byte?)bDA_StructuralIntegrityLevel;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
			{
				b = (byte?)bDA_StructuralIntegrityLevel;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
				{
					return "Heavy damage";
				}
				b = (byte?)bDA_StructuralIntegrityLevel;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
				{
					return "Destroyed";
				}
				return theStructuralIntegrity.ToString();
			}
			return "Medium damage";
		}
		return "Light damage";
	}

	public static string ToEnglishString(this CommDevice.EnumCommQuality theEnum)
	{
		switch (theEnum)
		{
		case CommDevice.EnumCommQuality.TacP:
			return "Tac Picture / ASUW/ASW";
		case CommDevice.EnumCommQuality.GLoc:
			return "General Location";
		case CommDevice.EnumCommQuality.None:
			return "None";
		default:
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			string result = default(string);
			return result;
		}
		case CommDevice.EnumCommQuality.FMV:
			return "Full Motion Video";
		case CommDevice.EnumCommQuality.BMD:
			return "BMD-grade Fire COntrol";
		case CommDevice.EnumCommQuality.AAW:
			return "AAW-grade Fire Control";
		}
	}

	internal static string ToEnglishString(this Weapon._WeaponType theType)
	{
		return theType switch
		{
			Weapon._WeaponType.Torpedo => "Torpedo", 
			Weapon._WeaponType.DepthCharge => "Depth Charge", 
			Weapon._WeaponType.Sonobuoy => "Sonobuoy", 
			Weapon._WeaponType.BottomMine => "Bottom Mine", 
			Weapon._WeaponType.MooredMine => "Moored Mine", 
			Weapon._WeaponType.FloatingMine => "Floating Mine", 
			Weapon._WeaponType.MovingMine => "Moving Mine", 
			Weapon._WeaponType.RisingMine => "Rising Mine", 
			Weapon._WeaponType.DriftingMine => "Drifting Mine", 
			Weapon._WeaponType.DummyMine => "Dummy Mine", 
			Weapon._WeaponType.SensorPod => "Sensor/EW Pod", 
			Weapon._WeaponType.DropTank => "Drop Tank", 
			Weapon._WeaponType.BuddyStore => "Buddy Store", 
			Weapon._WeaponType.FerryTank => "Ferry Tank", 
			Weapon._WeaponType.GuidedWeapon => "Guided Weapon", 
			Weapon._WeaponType.Rocket => "Rocket", 
			Weapon._WeaponType.IronBomb => "Unguided Bomb", 
			Weapon._WeaponType.Gun => "Gun", 
			Weapon._WeaponType.Decoy_Expendable => "Decoy (Expendable)", 
			Weapon._WeaponType.Decoy_Towed => "Decoy (Towed)", 
			Weapon._WeaponType.Decoy_Vehicle => "Decoy (Vehicle)", 
			Weapon._WeaponType.TrainingRound => "Training Round", 
			Weapon._WeaponType.UAV_Expendable => "UAV (Expendable)", 
			Weapon._WeaponType.None => "None", 
			Weapon._WeaponType.Cargo => "Cargo", 
			Weapon._WeaponType.Troops => "Troops", 
			Weapon._WeaponType.Paratroops => "Paratroops", 
			Weapon._WeaponType.HGV => "HGV", 
			Weapon._WeaponType.Laser => "Laser", 
			Weapon._WeaponType.Microwave => "Microwave (HPM)", 
			Weapon._WeaponType.LaserDazzler => "Laser Dazzler", 
			Weapon._WeaponType.RV => "RV", 
			Weapon._WeaponType.BallisticMissile => "Ballistic Missile", 
			_ => theType.ToString(), 
		};
	}

	internal static string ToEnglishString(this GlobalVariables.TargetVisualSizeClass theSize)
	{
		return theSize switch
		{
			GlobalVariables.TargetVisualSizeClass.Stealthy => "Extra small", 
			GlobalVariables.TargetVisualSizeClass.VSmall => "Very small", 
			GlobalVariables.TargetVisualSizeClass.Small => "Small", 
			GlobalVariables.TargetVisualSizeClass.Medium => "Medium", 
			GlobalVariables.TargetVisualSizeClass.Large => "Large", 
			GlobalVariables.TargetVisualSizeClass.VLarge => "Very large", 
			GlobalVariables.TargetVisualSizeClass.Unknown => "Unknown", 
			_ => theSize.ToString(), 
		};
	}

	public static string ToEnglishString(this Weapon.GEnum1 theClass)
	{
		switch (theClass)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return theClass.ToString();
		case Weapon.GEnum1.WW2eraManualDeadReckoning:
			return "WW2-era manual dead-reckoning";
		case Weapon.GEnum1.WW2eraSextant:
			return "WW2-era sextant (manual stellar)";
		case Weapon.GEnum1.INS_1950s:
			return "1950S INS";
		case Weapon.GEnum1.INS_1960s:
			return "1960S INS";
		case Weapon.GEnum1.INS_1970s:
			return "1970S INS";
		case Weapon.GEnum1.INS_1980s:
			return "1980S INS";
		case Weapon.GEnum1.INS_1990s_TacticalWeapon:
			return "1990S+ tactical weapon INS";
		case Weapon.GEnum1.INS_1990s_StrategicWeapon:
			return "1990S+ high-grade INS";
		case Weapon.GEnum1.INS_1990s_MEMSBased:
			return "1990S+ MEMS-Based INS";
		}
	}

	public static string ToEnglishString(this ActiveUnit._ActiveUnitStatus theStatus, ActiveUnit theAU)
	{
		ActiveUnit._ActiveUnitFuelState fuelState = theAU.FuelState;
		ActiveUnit._ActiveUnitWeaponState weaponState = theAU.WeaponState;
		string text = "";
		switch (fuelState)
		{
		case ActiveUnit._ActiveUnitFuelState.IsBingo:
			text = "Bingo";
			break;
		case ActiveUnit._ActiveUnitFuelState.IsJoker:
			text = "Joker";
			break;
		case ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker:
			text = "RTB order cancelled after reaching fuel/weapon state";
			break;
		}
		switch (weaponState)
		{
		case ActiveUnit._ActiveUnitWeaponState.IsWinchester:
			if (Operators.CompareString(text, "", false) != 0)
			{
				text += " And ";
			}
			text += "Winchester";
			break;
		case ActiveUnit._ActiveUnitWeaponState.IsWinchester_EngagingToO:
			if (Operators.CompareString(text, "", false) != 0)
			{
				text += " And ";
			}
			text += "Winchester, engaging opportunity target";
			break;
		case ActiveUnit._ActiveUnitWeaponState.IsShotgun:
			if (Operators.CompareString(text, "", false) != 0)
			{
				text += " And ";
			}
			text += "Shotgun";
			break;
		case ActiveUnit._ActiveUnitWeaponState.IsShotgun_EngagingToO:
			if (Operators.CompareString(text, "", false) != 0)
			{
				text += " And ";
			}
			text += "Shotgun, engaging opportunity target";
			break;
		default:
			if (fuelState != ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker && weaponState == ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun)
			{
				text = "RTB order cancelled after reaching fuel/weapon state";
			}
			break;
		}
		if (Operators.CompareString(text, "", false) == 0 && theAU.AI.PrimaryPickupTarget != null)
		{
			text = "Pick up from " + theAU.AI.PrimaryPickupTarget.Name;
		}
		if (Operators.CompareString(text, "", false) != 0)
		{
			text = " (" + text + ")";
		}
		switch (theStatus)
		{
		case ActiveUnit._ActiveUnitStatus.RTB_Exhaustion:
			return "RTB (Exhaustion)";
		case ActiveUnit._ActiveUnitStatus.Unassigned:
		case ActiveUnit._ActiveUnitStatus.Manual_Unassigned:
		{
			if (!theAU.IsWeapon)
			{
				return "Unassigned" + text;
			}
			string text2 = "(none)";
			if (!Information.IsNothing((object)theAU.AI.PrimaryTarget))
			{
				if (!Information.IsNothing((object)theAU.AI.PrimaryTarget.Name))
				{
					text2 = theAU.AI.PrimaryTarget.Name;
				}
				else
				{
					Contact sideMasterContact = theAU.AI.PrimaryTarget.GetSideMasterContact(theAU.get_UnitSide(SetSideOnly: false));
					if (!Information.IsNothing((object)sideMasterContact))
					{
						text2 = sideMasterContact.Name;
					}
				}
			}
			return "Target " + text2;
		}
		case ActiveUnit._ActiveUnitStatus.OnPlottedCourse:
		{
			Waypoint waypoint = theAU.Navigator.PlottedCourse.FirstOrDefault();
			if (waypoint == null)
			{
				return "On Plotted Course " + text;
			}
			return "On Plotted Course (" + waypoint.Description + " " + waypoint.Name + ") " + text;
		}
		case ActiveUnit._ActiveUnitStatus.EngagedOffensive:
		{
			byte? b = (byte?)theAU.Doctrine.get_MaintainStandoff(theAU.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				return "Engaged Offensive (Standoff)" + text;
			}
			return "Engaged Offensive" + text;
		}
		case ActiveUnit._ActiveUnitStatus.EngagedDefensive:
			return "Engaged Defensive" + text;
		case ActiveUnit._ActiveUnitStatus.OnAttackRun:
			return "On Attack Run" + text;
		case ActiveUnit._ActiveUnitStatus.OnPatrol:
			return "On Patrol" + text;
		case ActiveUnit._ActiveUnitStatus.RTB:
			return "RTB" + text;
		case ActiveUnit._ActiveUnitStatus.Tasked:
			if (!theAU.AI.IsEscort)
			{
				return "Tasked On mission" + text;
			}
			return "Mission escort " + text;
		case ActiveUnit._ActiveUnitStatus.FormingUp:
			return "Forming Up" + text;
		case ActiveUnit._ActiveUnitStatus.RTB_Manual:
			return "RTB (As ordered)" + text;
		case ActiveUnit._ActiveUnitStatus.OnSupportMission:
			return "On Support Mission" + text;
		case ActiveUnit._ActiveUnitStatus.OnFerryMission:
			return "On Ferry Mission" + text;
		case ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint:
			return "Heading To refuel point" + text;
		case ActiveUnit._ActiveUnitStatus.Refuelling:
			return "Refuelling" + text;
		case ActiveUnit._ActiveUnitStatus.RTB_MissionOver:
			return "RTB (Mission over)" + text;
		case ActiveUnit._ActiveUnitStatus.GroupLead_SlowingToAllowFormUp:
			return "Slowing down (To allow group To form up)" + text;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return theStatus.ToString();
		case ActiveUnit._ActiveUnitStatus.RTB_Group:
			return "RTB (Group Order)" + text;
		case ActiveUnit._ActiveUnitStatus.RTB_CalledOff:
			return "RTB (Called Off)" + text;
		case ActiveUnit._ActiveUnitStatus.WaitForPathfinder:
			return "Waiting For pathfinder-generated course";
		case ActiveUnit._ActiveUnitStatus.AttemptingToReestablishComms:
			return "Attempting To re-establish comms";
		case ActiveUnit._ActiveUnitStatus.AvoidingWeaponEffects:
			return "Avoiding Weapon Effects" + text;
		case ActiveUnit._ActiveUnitStatus.RTB_CommsLost:
			return "RTB (Comms Lost)";
		case ActiveUnit._ActiveUnitStatus.OnFireMission:
			return "On fire mission";
		}
	}

	public static void FormIntoGroups(this List<ActiveUnit> UnitsCollection, Scenario theScen, Side theSide, GroupingLogic theGroupingLogic, Mission theMission = null, bool CalledFromUI = false)
	{
		try
		{
			if (UnitsCollection.Count < 2)
			{
				return;
			}
			foreach (ActiveUnit item in UnitsCollection)
			{
				if (item.get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					item.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
				}
			}
			if ((from theAU in UnitsCollection
				select (theAU) into theAU
				where theAU.IsAircraft
				select theAU).Count() == UnitsCollection.Count)
			{
				switch (theGroupingLogic)
				{
				case GroupingLogic.SplitByType:
				{
					IEnumerable<int> enumerable = UnitsCollection.Select([SpecialName] (ActiveUnit AU) => ((Aircraft)AU).LoadoutDBID).Distinct();
					{
						_Closure$__148-0 closure$__148- = default(_Closure$__148-0);
						foreach (int item2 in enumerable)
						{
							closure$__148- = new _Closure$__148-0(closure$__148-);
							closure$__148-.$VB$Local_theInt = item2;
							List<ActiveUnit> list = new List<ActiveUnit>();
							IEnumerable<ActiveUnit> enumerable2 = UnitsCollection.Where(closure$__148-._Lambda$__3);
							foreach (ActiveUnit item3 in enumerable2)
							{
								list.Add(item3);
							}
							if (list.Count > 1)
							{
								Group obj2 = new Group(ref theScen, ref theSide, list);
								if (theMission != null)
								{
									obj2.Doctrine = theMission.Doctrine.CopyDoctrine(ref theMission.Doctrine, obj2, ref theScen);
								}
							}
						}
						break;
					}
				}
				case GroupingLogic.MixedGroup:
				{
					Group obj = new Group(ref theScen, ref theSide, UnitsCollection);
					if (theMission != null)
					{
						obj.Doctrine = theMission.Doctrine.CopyDoctrine(ref theMission.Doctrine, obj, ref theScen);
					}
					break;
				}
				}
				return;
			}
			switch (theGroupingLogic)
			{
			case GroupingLogic.MixedGroup:
			{
				Group obj4 = new Group(ref theScen, ref theSide, UnitsCollection);
				if (theMission != null)
				{
					obj4.Doctrine = theMission.Doctrine.CopyDoctrine(ref theMission.Doctrine, obj4, ref theScen);
				}
				List<ActiveUnit>[] Domains = null;
				if (Group.SortUnitsByDomain(UnitsCollection, ref Domains) <= 1)
				{
					break;
				}
				List<ActiveUnit>[] array = Domains;
				foreach (List<ActiveUnit> selectedUnits in array)
				{
					Group obj5 = new Group(ref theScen, ref theSide, selectedUnits);
					if (theMission != null)
					{
						obj5.Doctrine = theMission.Doctrine.CopyDoctrine(ref theMission.Doctrine, obj5, ref theScen);
					}
				}
				break;
			}
			case GroupingLogic.SplitByType:
			{
				Dictionary<Group.GroupType, List<ActiveUnit>> dictionary = Group.SortUnitsByIdealGroupType(UnitsCollection);
				List<string> list2 = new List<string>();
				foreach (KeyValuePair<Group.GroupType, List<ActiveUnit>> item4 in dictionary)
				{
					if (item4.Value.Count > 1)
					{
						list2.Add(item4.Key.ToString() + " (" + item4.Value.Count + " units)");
						List<ActiveUnit> list3 = new List<ActiveUnit>();
						list3.AddRange(item4.Value);
						Group obj3 = new Group(ref theScen, ref theSide, list3);
						if (theMission != null)
						{
							obj3.Doctrine = theMission.Doctrine.CopyDoctrine(ref theMission.Doctrine, obj3, ref theScen);
						}
					}
				}
				if (list2.Count > 0)
				{
					string text = "Created group";
					if (list2.Count > 1)
					{
						text += "s";
					}
					text += Environment.NewLine;
					text += string.Join(Environment.NewLine, list2);
					if (CalledFromUI)
					{
						GameGeneral.SendMessageBoxToUI(text, theSide, "Group creation");
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101092", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static float TurnRadius(float SpeedInKnots, float TurnRate)
	{
		return (float)((double)(float)((double)((float)((double)SpeedInKnots * 1.68780986) * (360f / TurnRate)) / 3.14159265358979 / 2.0) / 6076.11549);
	}

	internal static List<List<GraphicsPath>> splitList(List<GraphicsPath> SourceList, int ListSize = 30)
	{
		List<List<GraphicsPath>> list = new List<List<GraphicsPath>>();
		for (int i = 0; i < SourceList.Count; i += ListSize)
		{
			list.Add(SourceList.GetRange(i, Math.Min(ListSize, SourceList.Count - i)));
		}
		return list;
	}

	internal static List<List<Point[]>> splitList(List<Point[]> SourceList, int ListSize = 30)
	{
		List<List<Point[]>> list = new List<List<Point[]>>();
		for (int i = 0; i < SourceList.Count; i += ListSize)
		{
			list.Add(SourceList.GetRange(i, Math.Min(ListSize, SourceList.Count - i)));
		}
		return list;
	}

	internal static bool FindTangents(GeoPoint center, GeoPoint TheRadiusPoint, GeoPoint external_point, ref GeoPoint pt1, ref GeoPoint pt2)
	{
		double num2 = default(double);
		double num = num2;
		double num4 = default(double);
		float num3 = (float)Math.Sqrt(num4 * num4 + num * num);
		double num6 = default(double);
		double num5 = num6;
		double num8 = default(double);
		double num7 = num8 * num8 + num5 * num5;
		if (num7 < (double)(num3 * num3))
		{
			pt1 = null;
			pt2 = null;
			return false;
		}
		double num9 = Math.Sqrt(num7 - (double)(num3 * num3));
		smethod_4(0.0, 0.0, num3, num8, num6, (float)num9, ref pt1, ref pt2);
		MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(pt1.Longitude, pt1.Latitude);
		MercatorProjection.TCoord tCoord2 = MercatorProjection.toGeoCoord(pt2.Longitude, pt2.Latitude);
		pt1.Longitude = tCoord.Lon;
		pt1.Latitude = tCoord.Lat;
		pt2.Longitude = tCoord2.Lon;
		pt2.Latitude = tCoord2.Lat;
		return true;
	}

	private static int smethod_4(double double_0, double double_1, float float_2, double double_2, double double_3, float float_3, ref GeoPoint geoPoint_0, ref GeoPoint geoPoint_1)
	{
		double num = double_0 - double_2;
		double num2 = double_1 - double_3;
		double num3 = Math.Sqrt(num * num + num2 * num2);
		if (num3 > (double)(float_2 + float_3))
		{
			geoPoint_0 = new GeoPoint(double.NaN, double.NaN);
			geoPoint_1 = new GeoPoint(double.NaN, double.NaN);
			return 0;
		}
		if (num3 < (double)Math.Abs(float_2 - float_3))
		{
			geoPoint_0 = new GeoPoint(double.NaN, double.NaN);
			geoPoint_1 = new GeoPoint(double.NaN, double.NaN);
			return 0;
		}
		if (num3 == 0.0 && float_2 == float_3)
		{
			geoPoint_0 = new GeoPoint(double.NaN, double.NaN);
			geoPoint_1 = new GeoPoint(double.NaN, double.NaN);
			return 0;
		}
		double num4 = ((double)(float_2 * float_2 - float_3 * float_3) + num3 * num3) / (2.0 * num3);
		double num5 = Math.Sqrt((double)(float_2 * float_2) - num4 * num4);
		double num6 = double_0 + num4 * (double_2 - double_0) / num3;
		double num7 = double_1 + num4 * (double_3 - double_1) / num3;
		geoPoint_0 = new GeoPoint((float)(num6 + num5 * (double_3 - double_1) / num3), (float)(num7 - num5 * (double_2 - double_0) / num3));
		geoPoint_1 = new GeoPoint((float)(num6 - num5 * (double_3 - double_1) / num3), (float)(num7 + num5 * (double_2 - double_0) / num3));
		if (num3 == (double)(float_2 + float_3))
		{
			return 1;
		}
		return 2;
	}

	internal static TurnDirection DetermineTurnDirection(float Bearing1, float Bearing2)
	{
		Bearing2 = Math2.NormalizeBearing(Bearing2 - Bearing1);
		Bearing1 = 0f;
		if (Bearing2 > 180f)
		{
			return TurnDirection.TurnLeft;
		}
		return TurnDirection.TurnRight;
	}

	internal static float RelativeAngleBetweenBearings(float bearing1, float bearing2, bool PreserveLeftRight = false)
	{
		float num = Math2.NormalizeBearing(bearing1 - bearing2);
		if (num > 180f)
		{
			num = 0f - (360f - num);
		}
		if (!PreserveLeftRight)
		{
			num = Math.Abs(num);
		}
		return num;
	}

	internal static bool Contains(this string source, string toCheck, StringComparison comp)
	{
		return source.IndexOf(toCheck, comp) >= 0;
	}

	internal static T[] CombineMultipleArrays<T>(List<T[]> theList)
	{
		T[] array = new T[theList.Sum([SpecialName] (T[] arr) => arr.Length) - 1 + 1];
		int num = 0;
		foreach (T[] the in theList)
		{
			Array.Copy(the, 0, array, num, the.Length);
			num += the.Length;
		}
		return array;
	}

	internal static T[] CombineArrays<T>(T[] firstArray, T[] secondArray)
	{
		if (firstArray == null)
		{
			return secondArray;
		}
		if (secondArray == null)
		{
			return firstArray;
		}
		T[] array = new T[firstArray.Length + secondArray.Length - 1 + 1];
		firstArray.CopyTo(array, 0);
		secondArray.CopyTo(array, firstArray.Length);
		return array;
	}

	internal static T[] MergeUsingBlockCopy<T>(T[] firstArray, T[] secondArray)
	{
		T[] array = new T[firstArray.Length + secondArray.Length - 1 + 1];
		Buffer.BlockCopy(firstArray, 0, array, 0, firstArray.Length);
		Buffer.BlockCopy(secondArray, 0, array, firstArray.Length, secondArray.Length);
		return array;
	}

	internal static int[] MergeUsingBlockCopy(int[] firstArray, int[] secondArray)
	{
		int[] array = new int[firstArray.Length + secondArray.Length - 1 + 1];
		Buffer.BlockCopy(firstArray, 0, array, 0, firstArray.Length);
		Buffer.BlockCopy(secondArray, 0, array, firstArray.Length, secondArray.Length);
		return array;
	}

	internal static long FindPrimeNumber(int n)
	{
		int num = 0;
		long location = 2L;
		while (num < n)
		{
			long num2 = 2L;
			int num3 = 1;
			for (; num2 * num2 <= location; num2++)
			{
				if (location % num2 == 0L)
				{
					num3 = 0;
					break;
				}
			}
			if (num3 > 0)
			{
				num++;
			}
			location++;
		}
		return Interlocked.Decrement(ref location);
	}

	internal static List<T>[] smethod_5<T>(this IList<T> list, int totalPartitions)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (totalPartitions < 1)
		{
			throw new ArgumentOutOfRangeException("totalPartitions");
		}
		int count = list.Count;
		List<T>[] array = new List<T>[totalPartitions - 1 + 1];
		int num = (int)Math.Ceiling((double)count / (double)totalPartitions);
		int num2 = 0;
		int num3 = array.Length - 1;
		for (int i = 0; i <= num3; i++)
		{
			array[i] = new List<T>();
			int num4 = num2;
			int num5 = num2 + num - 1;
			for (int j = num4; j <= num5 && j < count; j++)
			{
				array[i].Add(list[j]);
			}
			num2 += num;
		}
		return array;
	}

	internal static string ToEnglishString(this ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker theResult)
	{
		return theResult switch
		{
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.None => "None", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Success => "Success", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_Unknown => "Failed - Unknown reason", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_NoSuitableFuelOrStoresToTransfer => "Failed - No suitable fuel Or stores To transfer", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_CannotIntercept => "Failed - Cannot intercept the provider", 
			ActiveUnit_DockingOps.ResultOfAttemptToRendezvousWithTanker.Fail_ProviderSmallerThanReceiver => "Failed - The provider Is smaller than the receiver And Is Not a dedicated tanker/UNREP platform", 
			_ => theResult.ToString(), 
		};
	}

	internal static List<ActiveUnit> ToList_NoLINQ(this HashSet<ActiveUnit> theHashset)
	{
		List<ActiveUnit> list = new List<ActiveUnit>(theHashset.Count);
		HashSet<ActiveUnit>.Enumerator enumerator = theHashset.GetEnumerator();
		while (enumerator.MoveNext())
		{
			list.Add(enumerator.Current);
		}
		return list;
	}

	internal static List<T> ToList_NoLINQ<T>(this T[] theArray)
	{
		int num = theArray.Length;
		List<T> list = new List<T>(num);
		int num2 = num;
		for (int i = 0; i <= num2; i++)
		{
			list[i] = theArray[i];
		}
		return list;
	}

	public static Group GetByName(this List<Group> theList, string theName)
	{
		foreach (Group the in theList)
		{
			if (string.CompareOrdinal(the.Name, theName) == 0)
			{
				return the;
			}
		}
		return null;
	}

	public static bool ContainsByName(this List<Group> theList, string theName)
	{
		foreach (Group the in theList)
		{
			if (string.CompareOrdinal(the.Name, theName) == 0)
			{
				return true;
			}
		}
		return false;
	}

	internal static string EscapeLikeValue(string stringWithIncompatibleChar)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		int num = stringWithIncompatibleChar.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			char c = stringWithIncompatibleChar[i];
			if (Operators.CompareString(Conversions.ToString(c), "*", false) != 0 && Operators.CompareString(Conversions.ToString(c), "%", false) != 0 && Operators.CompareString(Conversions.ToString(c), "[", false) != 0 && Operators.CompareString(Conversions.ToString(c), "]", false) != 0)
			{
				if (Operators.CompareString(Conversions.ToString(c), "\\'", false) != 0)
				{
					stringBuilder.Append(c);
				}
				else
				{
					stringBuilder.Append("''");
				}
			}
			else
			{
				stringBuilder.Append("[").Append(c).Append("]");
			}
		}
		stringBuilder.ToString();
		StringBuilderCache.Free(stringBuilder);
		return stringBuilder.ToString();
	}

	internal static bool IsNetworkPath(string path)
	{
		int result;
		if (path.StartsWith("/"))
		{
			result = 1;
		}
		else
		{
			if (!path.StartsWith("\\"))
			{
				string pathRoot = Path.GetPathRoot(path);
				return new DriveInfo(pathRoot).DriveType == DriveType.Network;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	internal static List<string> FetchMultilineString(string StringToProcess, int MaxCharLength, bool AllowTruncatedWords = false)
	{
		List<string> list = new List<string>();
		string text = "";
		list.Add("");
		foreach (char c in StringToProcess)
		{
			if (Operators.CompareString(Conversions.ToString(c), " ", false) == 0)
			{
				list[list.Count - 1] += text;
				text = "";
				list[list.Count - 1] += " ";
			}
			else
			{
				text += Conversions.ToString(c);
			}
			if (list[list.Count - 1].Length + text.Length > MaxCharLength - 1)
			{
				list.Add(text);
				text = "";
			}
		}
		if (list.Count == 1)
		{
			list[0] += text;
			return list;
		}
		if (text.Length > 0)
		{
			list.Add(text);
		}
		return list;
	}

	internal static Image ImageFromFile_Fast(string path)
	{
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream(File.ReadAllBytes(path));
		return Image.FromStream((Stream)memoryStream, false, false);
	}

	internal static int smethod_6(DateTime time)
	{
		DayOfWeek dayOfWeek = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
		if (dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Wednesday)
		{
			time = time.AddDays(3.0);
		}
		return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
	}

	public static void FormatXML_DiskFile(string theFileName)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		try
		{
			XmlDocument val = new XmlDocument();
			val.Load(theFileName);
			XmlTextWriter val2 = new XmlTextWriter(theFileName, Encoding.UTF8);
			val2.Formatting = (Formatting)1;
			val.Save((XmlWriter)(object)val2);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static string SpeedToEnglishString(float SpeedInKnots, int HowManyDecimals, Game.GamePreferences.SpeedUnitSetting PreferredSpeedUnit)
	{
		return PreferredSpeedUnit switch
		{
			Game.GamePreferences.SpeedUnitSetting.Knots => Conversions.ToString(Math.Round(SpeedInKnots, HowManyDecimals)) + " kts", 
			Game.GamePreferences.SpeedUnitSetting.KPH => Conversions.ToString(Math.Round((double)SpeedInKnots * 1.852, HowManyDecimals)) + " KPH", 
			Game.GamePreferences.SpeedUnitSetting.MPH => Conversions.ToString(Math.Round((double)SpeedInKnots * 1.15078, HowManyDecimals)) + " MPH", 
			_ => Conversions.ToString(Math.Round(SpeedInKnots, 0)) + " kts", 
		};
	}

	internal static int GetSeconds(DateTime theTime)
	{
		return (theTime.Hour * 60 + theTime.Minute) * 60 + theTime.Second;
	}
}
